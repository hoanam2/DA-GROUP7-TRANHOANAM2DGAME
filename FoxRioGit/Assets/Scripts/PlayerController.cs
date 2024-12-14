using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _anim;

    float _moveHorizontal;
    float _moveSpeed = 5f;
    
    bool _isGrounded { get; set; }
    bool _isJumping { get; set; }

    bool isFacingRight = true;

    float _jumpHight = 5f;
    float _jumpTime = 1f;
    float distance = 1f;

    float _jumpForce => (2f * _jumpHight) / (_jumpTime / 2);
    float gravity => (-2f * _jumpHight) / Mathf.Pow((_jumpTime / 2),2);
   
    Vector2 _jumpMove;
    Vector2 _velocity;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //xet dk xem Player co tren mat phang/mat dat
        _isGrounded = _rb.Raycast(Vector2.down,distance);
        if (_isGrounded)
        {
            _anim.SetBool("isJumping", false);
            _anim.SetBool("Grounded", true);
            _anim.SetBool("isFalling", false);
            jumping();
        }
        else
        {
            _anim.SetBool("isJumping",true);
            _anim.SetBool("Grounded", false);
        }
        ApplyGravity();
        Movement();
        FlipSprite();

    }
    void FixedUpdate()
    {
        
    }
    //movement of character
    private void Movement()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (_moveHorizontal != 0)
        {
            _anim.SetBool("isRunning", true);
            _rb.velocity = new Vector2(_moveHorizontal * _moveSpeed,_rb.velocity.y);
        }
        if (_rb.Raycast(Vector2.right * _rb.velocity.x,distance))
        {
            _rb.velocity = new Vector2(_moveHorizontal * _moveSpeed, _rb.velocity.y);
        }
        else if (_moveHorizontal == 0)
        { 
            _anim.SetBool("isRunning",false);
            _rb.velocity = new Vector2(0f,_rb.velocity.y);
        }
    }
    //jumping for character
    void jumping()
    {
        _velocity.y = Mathf.Max(_velocity.y, 0f);
        _isJumping = _velocity.y > 0f;
       
        if (Input.GetButtonDown("Jump") && _isJumping == false)
        {
            _velocity.y = _jumpForce;
            _isJumping = true;
            _anim.SetBool("isJumping", true);
            _anim.SetBool("Grounded",false);
        }
        if (Input.GetButton("Jump")&& _isJumping == false)
        {
            if (_isGrounded)
            {
                _anim.SetBool("isJumping", false);
                _anim.SetBool("isFalling", false);
                _anim.SetBool("Grounded", true);
            }
        }
    }
    //ap dung vat ly cho Player vao trong viec nhay
    void ApplyGravity()
    {
        bool falling = _rb.velocity.y < -10f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        _velocity.y += gravity * multiplier * Time.deltaTime;
        _velocity.y = Mathf.Max(_velocity.y, gravity / 2f);
        
        if( _rb.velocity.y < -10f)
            _anim.SetBool("isFalling", true);

        _rb.velocity = new Vector2(0f, _velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // bounce off enemy head
            if (transform.DotTest(collision.transform, Vector2.down))
            {
                _velocity.y = _jumpForce / 1.5f;
                _isJumping = true;
            }
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            // stop vertical movement if mario bonks his head
            if (transform.DotTest(collision.transform, Vector2.up))
            {
                _velocity.y = 0f;
            }
        }
    }
    void FlipSprite()
    {
        if(isFacingRight && _moveHorizontal <0f || !isFacingRight && _moveHorizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    
}

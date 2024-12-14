using UnityEngine;
public class EnityMovement : MonoBehaviour
{
    public float _movespeed = 2f;
    public Vector2 direction =  Vector2.left;
                                                                 
    float distance = 0.59f;

    private Rigidbody2D _enerb;
    private Vector2 _velocity;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _enerb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        enabled = false;
    }
    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        _enerb.WakeUp();
    }

    private void OnDisable()
    {
        _enerb.velocity = Vector2.zero;
        _enerb.Sleep();
    }

    private void FixedUpdate()
    {
        _velocity.x = direction.x * _movespeed;
        _velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        _enerb.MovePosition(_enerb.position + _velocity * Time.fixedDeltaTime);

        if (_enerb.Raycast(direction,distance))
        {
            direction = -direction;
            _sprite.flipX = !_sprite.flipX;
        }
        if (_enerb.Raycast(Vector2.down,distance))
        {
            _velocity.y = Mathf.Max(_velocity.y, 0f);
        }
    }
}

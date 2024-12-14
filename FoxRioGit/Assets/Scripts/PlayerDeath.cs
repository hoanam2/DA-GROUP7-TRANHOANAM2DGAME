using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    Animator _ani;
    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Animation();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Animation()
    {
        _ani = GetComponent<Animator>();
        spriteRenderer.sortingOrder = 10;
        _ani.SetBool("Death",true);
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        PlayerController playerMovement = GetComponent<PlayerController>();
        EnityMovement entityMovement = GetComponent<EnityMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        if (entityMovement != null)
        {
            entityMovement.enabled = false;
        }
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 0.75f;

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;
        Vector3 bottomEdge = Camera.main.ScreenToWorldPoint(Vector3.zero);

        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);    
    }
}

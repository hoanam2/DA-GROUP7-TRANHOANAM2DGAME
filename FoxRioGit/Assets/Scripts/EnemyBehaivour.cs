using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivour : MonoBehaviour
{
    private Sprite flatSprite;

    Animator _ani;

    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                Death();
                ScoreManager.Instance.AddScore(1000);
            }
            else
            {
                player.Death();
                TimeManager.Instance.TimeStop();
            }
        }
    }
    private void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnityMovement>().enabled = false;
        _ani.SetBool("Death", true);
        Destroy(gameObject, 0.5f);
    }
}

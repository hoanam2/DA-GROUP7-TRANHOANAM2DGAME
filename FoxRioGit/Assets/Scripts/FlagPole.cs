using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public GameObject flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(1000);
            StartCoroutine(MoveToPosition(flag.transform, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(other.transform));
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private IEnumerator MoveToPosition(Transform transform, Vector3 position)
    {
        while (Vector3.Distance(transform.position, position) > 0.125f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = position;
    }

    private IEnumerator LevelCompleteSequence(Transform player)
    {
        player.GetComponent<Player>().enabled = false;
       
        yield return MoveToPosition(player, poleBottom.position);
    }
}

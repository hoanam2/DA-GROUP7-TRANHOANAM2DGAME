using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                ScoreManager.Instance.AddScore(100);
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                ScoreManager.Instance.AddScore(1000);
                break;

            case Type.MagicMushroom:
                //PointPopUp.Instance.PopUp();
                ScoreManager.Instance.AddScore(1000);
                break;
        }

        Destroy(gameObject);
    }
}

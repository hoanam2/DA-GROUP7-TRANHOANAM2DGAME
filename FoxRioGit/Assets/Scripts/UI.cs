using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text TMP_Score;
    public TMP_Text TMP_Lives;
    public TMP_Text TMP_Coins;
    public TMP_Text TMP_World;
    public TMP_Text TMP_Time;

    private void Start()
    {
        TMP_Score.text = "POINT \n" + ScoreManager.Instance.Score.ToString();
        TMP_Lives.text = "LIVES \n" + GameManager.Instance.Lives.ToString();
        TMP_Coins.text = "COIN \n" + GameManager.Instance.Coins.ToString();
        TMP_World.text = "WORLD \n" + GameManager.Instance.World.ToString() + "-" + GameManager.Instance.Stage.ToString();
        TMP_Time.text = "TIME \n" + TimeManager.Instance.seconds.ToString();
    }
    private void Update()
    {
        TMP_Score.text = "POINT \n" + ScoreManager.Instance.Score.ToString();
        TMP_Lives.text = "LIVES \n" + GameManager.Instance.Lives.ToString();
        TMP_Coins.text = "COIN \n" + GameManager.Instance.Coins.ToString();
        TMP_World.text = "WORLD \n" + GameManager.Instance.World.ToString() + "-" + GameManager.Instance.Stage.ToString();
        TMP_Time.text = "TIME \n" + TimeManager.Instance.seconds.ToString();
    }
}

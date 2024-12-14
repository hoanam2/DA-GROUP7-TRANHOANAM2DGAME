using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    ScoreManager SM;
    TimeManager Time;
    GameManager GM;

    public TMP_Text TMP_Score;
    public TMP_Text TMP_Lives;
    public TMP_Text TMP_Coins;
    public TMP_Text TMP_World;
    public TMP_Text TMP_Time;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        SM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Time = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TMP_Score.text = "POINT \n" + SM.Score.ToString();
        TMP_Lives.text = "LIVES \n" + GM.Lives.ToString();
        TMP_Coins.text = "COIN \n" + GM.Coins.ToString();
        TMP_World.text = "WORLD \n" + GM.World.ToString() + "-" + GM.Stage.ToString();
        TMP_Time.text = "TIME \n" + Time.seconds.ToString();
    }
    private void Update()
    {
        TMP_Score.text = "POINT \n" + SM.Score.ToString();
        TMP_Lives.text = "LIVES \n" + GM.Lives.ToString();
        TMP_Coins.text = "COIN \n" + GM.Coins.ToString();
        TMP_World.text = "WORLD \n" + GM.World.ToString() + "-" + GM.Stage.ToString();
        TMP_Time.text = "TIME \n" + Time.seconds.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    SaveData saveData;

    private int m_world;
    private int m_stage;
    private int m_lives;
    private int m_coins;

    public int World 
    {
        get { return m_world; }
        set { m_world = value; }
    }
    public int Stage 
    { 
        get { return m_stage; }
        set { m_stage = value; }
    }
    public int Lives
    {
        get { return m_lives; }
        set { m_lives = value; }
    }
    public int Coins
    {
        get { return m_coins; }
        set { m_coins = value; }
    }
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
       NewGame();
    }
    public void NewGame()
    {
        Lives = 3;
        World = 1;
        Stage = 1;
        Coins = 0;
    }
    public void GameOver()
    {
        DeathManager.Instance.Death();
    }
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        Lives--;

        if (Lives > 0)
        {
            Coins = 0;
            ScoreManager.Instance.ResetScore();
            TimeManager.Instance.ResetTime();
            TimeManager.Instance.RunTime();
            ScenesManager.Instance.LoadNewGame();
        }
        else
        {
            GameOver();
        }
    }
    public void AddCoin()
    {
        Coins++;
    }
    public void AddLife()
    {
        Lives++;
    }
}

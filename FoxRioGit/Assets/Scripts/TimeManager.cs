using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance {  get; private set; }
    public float timeRemaining = 300;
    public bool timerIsRunning = false;
    public double seconds;

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
        // Starts the timer automatically
        timerIsRunning = true;
    }
    private void Update()
    {
        if (timerIsRunning)
        {
            TimeRunning();
            seconds = System.Math.Round(timeRemaining,0);
        }
    }
    public void TimeRunning()
    {
        if (timerIsRunning == true && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            TimeStop();
        }
    }
    public void TimeStop()
    {
        timerIsRunning = false;
    }
    public void RunTime()
    {
        timerIsRunning = true;
    }
    public void ResetTime()
    {
        timeRemaining = 300;
    }
}

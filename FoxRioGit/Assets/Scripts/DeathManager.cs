using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager Instance {  get; private set; }

    public GameObject DeathPanel;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
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
    public void Death()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resart()
    {
        DeathPanel.SetActive(false);
        GameManager.Instance.NewGame();
        ScenesManager.Instance.LoadNewGame();
        Time.timeScale = 1; 
    }
    public void Exit()
    {
        DeathPanel.SetActive(false);
        TimeManager.Instance.TimeStop();
        PlayerPrefs.SetInt("Save", 0);
        ScenesManager.Instance.LoadMenu();
        Time.timeScale = 1;
    }
}

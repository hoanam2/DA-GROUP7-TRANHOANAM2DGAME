using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        playerController.enabled = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PausePanel.SetActive(false);
        playerController.enabled = true;
        Time.timeScale = 1;
    }
    public void Exit()
    {
        PausePanel.SetActive(false);
        TimeManager.Instance.TimeStop();
        ScenesManager.Instance.SaveGame();
        ScenesManager.Instance.LoadMenu();
        Time.timeScale = 1;
    }
}

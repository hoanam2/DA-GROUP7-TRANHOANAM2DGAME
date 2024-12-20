using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    SaveData saveData;

    private void Start()
    {
        saveData = new SaveData();
    }
    public void Startnewgame()
    {
        GameManager.Instance.NewGame();
        TimeManager.Instance.ResetTime();
        TimeManager.Instance.RunTime();
        ScoreManager.Instance.ResetScore();
        ScenesManager.Instance.LoadNewGame();
    }
    public void ExitTheGame()
    {
        ScenesManager.Instance.ExitGame();
    }
    public void ContinueTheGame()
    {
        
    }
}

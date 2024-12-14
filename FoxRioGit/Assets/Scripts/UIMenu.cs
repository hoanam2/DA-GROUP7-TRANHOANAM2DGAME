using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public Button btt_NewGame;
    public Button btt_ExitGame;
    public Button btt_ContinueGame;

    private void Start()
    {
        btt_NewGame.onClick.AddListener(Startnewgame);
        btt_ExitGame.onClick.AddListener(ExitTheGame);
        btt_ContinueGame.onClick.AddListener(ContinueTheGame);
    }
    private void Startnewgame()
    {
        GameManager.Instance.NewGame();
        ScenesManager.Instance.LoadNewGame();
    }
    private void ExitTheGame()
    {
        ScenesManager.Instance.ExitGame();
    }
    private void ContinueTheGame()
    {
        ScenesManager.Instance.CountinueGame();
    }
}

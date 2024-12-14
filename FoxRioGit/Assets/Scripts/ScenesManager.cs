using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    public int currentsceneindex;
    public int scenetocontinue;

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
    public enum Scene
    {
        Menu,
        W1L1
    }
    public void LoadScene(int SceneIndex)
    {
        TimeManager.Instance.RunTime();
        SceneManager.LoadScene(SceneIndex);
    }
    public void LoadNewGame()
    {
        TimeManager.Instance.ResetTime();
        TimeManager.Instance.RunTime();
        SceneManager.LoadScene(Scene.W1L1.ToString());
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(Scene.Menu.ToString());
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SaveGame()
    {
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Save",currentsceneindex);
    }
    public void CountinueGame()
    {
        scenetocontinue = PlayerPrefs.GetInt("Save");

        if ( scenetocontinue != 0)
        {
            LoadScene(scenetocontinue);
        }
        else
        {
            return;
        }
    }
}

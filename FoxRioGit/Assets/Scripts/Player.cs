using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public CapsuleCollider2D capsuleCollider { get; private set; }

    private PlayerDeath _playerDeath;

    CinemachineVirtualCamera _camera;

    SaveData savedata;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        _playerDeath = GetComponent<PlayerDeath>();
        _camera = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        //savedata = SaveManager.Load();
        //TelePlayer(savedata);
    }
    public void Hit()
    {
        Death();
    }
    public void Death()
    {
       _playerDeath.enabled = true;
        _camera.gameObject.SetActive(false);
        GameManager.Instance.ResetLevel(1.5f);
    }
    public void TelePlayer(SaveData saveData)
    {
        gameObject.transform.position = new Vector3(saveData.playerlocationx, saveData.playerlocationy, saveData.playerlocationz);
    }
}

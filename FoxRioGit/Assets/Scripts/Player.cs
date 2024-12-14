using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider { get; private set; }

    private PlayerDeath _playerDeath;

    CinemachineVirtualCamera _camera;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        _playerDeath = GetComponent<PlayerDeath>();
        _camera = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    public void Hit()
    {
        Death();
    }
    public void Death()
    {
       _playerDeath.enabled = true;
        _camera.gameObject.SetActive(false);
        GameManager.Instance.ResetLevel(3f);
    }
}

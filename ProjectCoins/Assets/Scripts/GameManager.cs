using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _buttonE;
    [SerializeField] private GameObject _pauseMenu;
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckInput();
    }

    public void ActivateEButton()
    {
        _buttonE.SetActive(true);
    }

    public void DeactivateEButton()
    {
        _buttonE.SetActive(false);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        if (_pauseMenu.activeSelf)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

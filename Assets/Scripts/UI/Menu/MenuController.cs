using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;

    [Space]
    [SerializeField] private Button _startButton;

    [Space]
    [SerializeField] private PlayerInfoMenuView _player1Info;
    [SerializeField] private PlayerInfoMenuView _player2Info;

    #region Start
    private void Start()
    {
        SetButtons();
        SetListeners();
    }
    #endregion

    #region Buttons
    private void SetButtons()
    {
        _startButton.onClick.AddListener(StartGame);
        _startButton.interactable = false;

        _player1Info.Init(0);
        _player2Info.Init(1);
    }

    private void StartGame()
    {
        _gameData.StartGame(_player1Info.Name, _player1Info.AvatarID, _player2Info.Name, _player2Info.AvatarID);
        SceneManager.LoadScene(1);
    }
    #endregion

    #region InputFields
    private void SetListeners()
    {
        _player1Info.OnStateChanged += OnStateChangeListener;
        _player2Info.OnStateChanged += OnStateChangeListener;
    }

    private void OnStateChangeListener()
    {
        _startButton.interactable = _player1Info.IsReady && _player2Info.IsReady;
    }
    #endregion
}


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
    [SerializeField] private TMPro.TMP_InputField _player1NameInput;
    [SerializeField] private TMPro.TMP_InputField _player2NameInput;

    #region Start
    private void Start()
    {
        SetButtons();
        SetInputFields();
    }
    #endregion

    #region Buttons
    private void SetButtons()
    {
        _startButton.onClick.AddListener(StartGame);
        _startButton.interactable = false;
    }

    private void StartGame()
    {
        _gameData.StartGame(_player1NameInput.text, 0, _player2NameInput.text, 1);
        SceneManager.LoadScene(1);
    }
    #endregion

    #region InputFields
    private void SetInputFields()
    {
        _player1NameInput.onValueChanged.AddListener(OnValueChangeListener);
        _player2NameInput.onValueChanged.AddListener(OnValueChangeListener);
    }

    private void OnValueChangeListener(string value)
    {
        _startButton.interactable = !string.IsNullOrEmpty(_player1NameInput.text) && !string.IsNullOrEmpty(_player2NameInput.text);
    }
    #endregion
}


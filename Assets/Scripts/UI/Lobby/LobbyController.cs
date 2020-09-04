using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    [Space]
    [SerializeField] private Button _startButton;

    #region Start
    private void Start()
    {
        SetButtons();
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
        SceneManager.LoadScene(2);
    }
    #endregion
}

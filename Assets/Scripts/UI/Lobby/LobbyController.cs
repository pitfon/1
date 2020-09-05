using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;

    [Space]
    [SerializeField] private Button _startButton;

    [SerializeField] private List<PlayerLobbyContainer> _containers;

    #region Start
    private void Start()
    {
        SetButtons();
        SetContainers();
    }
    #endregion

    #region Containers
    private void SetContainers()
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (i < _gameData.PlayersData.Count)
            {
                _containers[i].Init(_gameData.PlayersData[i]);
            }
        }
    }
    #endregion

    #region Buttons
    private void SetButtons()
    {
        _startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    #endregion
}

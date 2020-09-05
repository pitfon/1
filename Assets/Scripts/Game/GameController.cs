using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private GameDataHolder _gameData;
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private GameUI _gameUI;

    [Space]
    [SerializeField] private PlayerReferences _player1References;
    [SerializeField] private PlayerReferences _player2References;

    public PlayerReferences Player1 => _player1References;
    public PlayerReferences Player2 => _player2References;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitData();
        InitPlayers();

        _mapGenerator.Init();
        _gameUI.Init(_gameData, Player1, Player2);
    }

    private void InitData()
    {
        _gameData.DebugCheck();

        Player1.Init(_gameData.PlayersData[0]);
        Player2.Init(_gameData.PlayersData[1]);
    }

    private void InitPlayers()
    {
        Player1.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[0].LookID));
        Player2.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[1].LookID));
    }
}

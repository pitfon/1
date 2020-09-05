using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;
    [SerializeField] private MapGenerator _mapGenerator;

    [Space]
    [SerializeField] private PlayerReferences _player1References;
    [SerializeField] private PlayerReferences _player2References;

    public PlayerReferences Player1 => _player1References;
    public PlayerReferences Player2 => _player2References;

    private void Start()
    {
        //_gameData.DebugCheck();
        _mapGenerator.Init();

        InitPlayers();
    }

    private void InitPlayers()
    {
        Player1.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[0].LookID));
        Player2.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[1].LookID));
    }
}

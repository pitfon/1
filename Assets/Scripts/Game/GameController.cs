using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private GameDataHolder _gameData;
    [SerializeField] private bool _debugCheck;

    [Space]
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private MobSpawner _mobSpawner;
    [SerializeField] private GameUI _gameUI;

    [Space]
    [SerializeField] private PlayerReferences _player1References;
    [SerializeField] private PlayerReferences _player2References;

    public PlayerReferences Player1 => _player1References;
    public PlayerReferences Player2 => _player2References;

    public MapGenerator MapGenerator => _mapGenerator;
    public MobSpawner MobSpawner => _mobSpawner;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitData();
        InitPlayers();
        InitEndEvents();

        _mapGenerator.Init();
        _mobSpawner.Init(_gameData);
        _gameUI.Init(_gameData, Player1, Player2);
    }

    private void InitData()
    {
        if (_debugCheck)
        {
            _gameData.DebugCheck();
        }

        Player1.Init(_gameData.PlayersData[0]);
        Player2.Init(_gameData.PlayersData[1]);
    }

    private void InitPlayers()
    {
        Player1.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[0].LookID));
        Player2.LookController.InitProfile(CharacterLooksHolder.Instance.GetLookProfile(_gameData.PlayersData[1].LookID));
    }

    private void InitEndEvents()
    {
        Player1.Health.OnDeath += CheckIsAlivePlayer;
        Player2.Health.OnDeath += CheckIsAlivePlayer;
        MobSpawner.OnEnd += OnAllMobsKilled;
    }

    private void CheckIsAlivePlayer(Health health)
    {
        Debug.Log(Player1.Health.Alive + " " + Player2.Health.Alive);
        if (!Player1.Health.Alive && !Player2.Health.Alive)
        {
            Debug.Log("Load Menu");
            SceneManager.LoadScene(0);
        }
    }

    private void OnAllMobsKilled()
    {
        if (Player1.Health.Alive || Player2.Health.Alive)
        {
            Debug.Log("All mobs Killed");

            _gameData.GameData.UpgradeLevel();
            _gameData.PlayersData.ForEach(x => x.UpdateMoney(100));

            Debug.Log("Load lobby");
            SceneManager.LoadScene(1);
        }
    }
}

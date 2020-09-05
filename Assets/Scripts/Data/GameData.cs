using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private string _startMoney;

    public List<PlayerData> PlayersData { get; private set; }

    public void StartGame(string player1Name, string player2Name)
    {
        PlayersData = new List<PlayerData>();

        PlayersData.Add(new PlayerData(player1Name));
        PlayersData.Add(new PlayerData(player2Name));
    }
}

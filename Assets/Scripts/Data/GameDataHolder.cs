using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameDataHolder : ScriptableObject
{
    public GameData GameData { get; private set; }
    public List<PlayerData> PlayersData { get; private set; }

    public void StartGame(string player1Name = "player1", int player1LookID = 0, string player2Name = "player2", int player2LookID = 0)
    {
        GameData = new GameData();

        PlayersData = new List<PlayerData>();
        PlayersData.Add(new PlayerData(player1Name, player1LookID));
        PlayersData.Add(new PlayerData(player2Name, player2LookID));
    }
}

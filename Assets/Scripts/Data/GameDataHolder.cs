using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameDataHolder : ScriptableObject
{
    public GameData GameData { get; private set; }
    public List<PlayerData> PlayersData { get; private set; }

    public void StartGame(string player1Name = "player1", string player2Name = "player2")
    {
        GameData = new GameData();

        PlayersData = new List<PlayerData>();
        PlayersData.Add(new PlayerData(player1Name));
        PlayersData.Add(new PlayerData(player2Name));
    }
}

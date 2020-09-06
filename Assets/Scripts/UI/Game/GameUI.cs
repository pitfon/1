using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _levelText;
    [SerializeField] private TMPro.TextMeshProUGUI _mobsLeftText;

    [SerializeField] private PlayerGameView _player1GameView;
    [SerializeField] private PlayerGameView _player2GameView;

    public void Init(GameDataHolder gameData, PlayerReferences player1, PlayerReferences player2)
    {
        _player1GameView.Init(player1);
        _player2GameView.Init(player2);

        _levelText.text = $"Level: {gameData.GameData.Level}";

        GameController.Instance.MobSpawner.OnMobDeath += UpdateMobsLeftText;
        UpdateMobsLeftText();
    }

    private void UpdateMobsLeftText()
    {
        _mobsLeftText.text = $"Left: {GameController.Instance.MobSpawner.MobsLeft}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;
    [SerializeField] private MapGenerator _mapGenerator;

    private void Start()
    {
        _gameData.DebugCheck();
        _mapGenerator.Init();
    }
}

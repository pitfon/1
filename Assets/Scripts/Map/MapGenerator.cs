using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;

    [Space]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private TileBase _ruleTile;
    [SerializeField] private Camera _camera;

    [Space]
    [SerializeField, Range(10, 100)] private int _baseWidth = 29;

    private int _width;
    private int _height;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _gameData.GameData.UpgradeLevel();

            GenerateMap();
            SetCamera();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _gameData.StartGame();

            GenerateMap();
            SetCamera();
        }
    }

    private void Start()
    {
        _gameData.StartGame();

        GenerateMap();
        SetCamera();
    }

    private void GenerateMap()
    {
        _width = _baseWidth + _gameData.GameData.Level;
        _height = Mathf.RoundToInt(_width * 0.5625f);

        _tilemap.ClearAllTiles();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _tilemap.SetTile(new Vector3Int(x, y, 0), _ruleTile);
            }
        }

    }

    private void SetCamera()
    {
        _camera.transform.position = new Vector3(_width / 2.0f, _height / 2.0f, -10);
        _camera.orthographicSize = _height/2.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameDataHolder _gameData;

    [Space]
    [SerializeField] private Camera _camera;

    [Space]
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private TileBase _groundTile;

    [Space]
    [SerializeField] private Tilemap _entryAndExitTilemap;
    [SerializeField] private TileBase _entryTile;
    [SerializeField] private TileBase _exitTile;

    [Space]
    [SerializeField, Range(10, 100)] private int _baseWidth = 29;

    private int _width;
    private int _height;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _gameData.GameData.UpgradeLevel();

            Init();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _gameData.StartGame();

            Init();
        }
    }

    public void Init()
    {
        GenerateMap();
        //SetExitAndEntry();
        SetCamera();
    }

    private void GenerateMap()
    {
        _width = _baseWidth + _gameData.GameData.Level;
        _height = Mathf.RoundToInt(_width * 0.5625f);

        _groundTilemap.ClearAllTiles();
        _entryAndExitTilemap.ClearAllTiles();

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _groundTilemap.SetTile(new Vector3Int(x, y, 0), _groundTile);
            }
        }
    }

    private void SetExitAndEntry()
    {
        int amount = _height % 2 == 0 ? 4 : 3;
        int decrease = _height % 2 == 0 ? -2 : -1;
        int height = Mathf.FloorToInt(_height / 2);

        for (int i = decrease; i < amount + decrease; i++)
        {
            for (int x = 0; x < 2; x++)
            {
                _entryAndExitTilemap.SetTile(new Vector3Int(-x, height + i, 0), _entryTile);
                _entryAndExitTilemap.SetTile(new Vector3Int(_width - 1 + x, height + i, 0), _exitTile);
            }
        }
    }

    private void SetCamera()
    {
        _camera.transform.position = new Vector3(_width / 2.0f, 10, _height / 2.0f);
        _camera.orthographicSize = _height / 2.0f;
    }
}

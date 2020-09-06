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

    public int Width { get; private set; }
    public int Height { get; private set; }

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
        Width = _baseWidth + _gameData.GameData.Level;
        Height = Mathf.RoundToInt(Width * 0.5f);

        _groundTilemap.ClearAllTiles();
        _entryAndExitTilemap.ClearAllTiles();

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _groundTilemap.SetTile(new Vector3Int(x, y, 0), _groundTile);
            }
        }
    }

    private void SetExitAndEntry()
    {
        int amount = Height % 2 == 0 ? 4 : 3;
        int decrease = Height % 2 == 0 ? -2 : -1;
        int height = Mathf.FloorToInt(Height / 2);

        for (int i = decrease; i < amount + decrease; i++)
        {
            for (int x = 0; x < 2; x++)
            {
                _entryAndExitTilemap.SetTile(new Vector3Int(-x, height + i, 0), _entryTile);
                _entryAndExitTilemap.SetTile(new Vector3Int(Width - 1 + x, height + i, 0), _exitTile);
            }
        }
    }

    private void SetCamera()
    {
        _camera.transform.position = new Vector3(Width / 2.0f, 10, Height / 1.65f);
        _camera.orthographicSize = Height / 1.65f;
    }
}

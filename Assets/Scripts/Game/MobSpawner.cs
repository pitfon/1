using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _mobPrefabs;

    private GameDataHolder _gameData;

    private List<GameObject> _mobsToSpawn = new List<GameObject>();
    private List<Health> _mobsSpawned = new List<Health>();

    private int _spawnLimit;

    public int MobsLeft => _mobsToSpawn.Count + _mobsSpawned.Count;

    public System.Action OnMobDeath;
    public System.Action OnEnd;

    private Vector3 _minPosition;
    private Vector3 _maxPosisition;

    public void Init(GameDataHolder gameData)
    {
        _gameData = gameData;
        _minPosition = new Vector3(3, 3, 3);
        _maxPosisition = new Vector3(GameController.Instance.MapGenerator.Width - 3, GameController.Instance.MapGenerator.Height - 3, 0);

        if (_gameData.GameData.Level <= _mobPrefabs.Count)
        {
            for (int i = 0; i < 5; i++)
            {
                _mobsToSpawn.Add(_mobPrefabs[_gameData.GameData.Level - 1]);
            }

            _spawnLimit = 1;
        }
        else
        {
            _mobsToSpawn = new List<GameObject>(_mobPrefabs.Random(_gameData.GameData.Level * 2));

            _spawnLimit = Mathf.FloorToInt(_gameData.GameData.Level / 3);
        }

        SpawnMobs();
    }

    private void SpawnMobs()
    {
        int spawnAmount = Mathf.Clamp(_spawnLimit, 0, _mobsToSpawn.Count);

        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject prefab = _mobsToSpawn.Random();
            _mobsToSpawn.Remove(prefab);

            GameObject mob = Instantiate(prefab);
            mob.transform.SetParent(transform);
            mob.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            mob.transform.localPosition = _minPosition.Random(_maxPosisition);

            Health mobHealth = mob.GetComponent<Health>();
            mobHealth.OnDeath += OnMobDeathListener;

            _mobsSpawned.Add(mobHealth);
        }
    }

    private void OnMobDeathListener(Health health)
    {
        _mobsSpawned.Remove(health);
        OnMobDeath?.Invoke();

        SpawnMobs();

        if (_mobsSpawned.Count == 0)
        {
            OnEnd?.Invoke();
            OnEnd = null;
        }
    }

    private void OnDestroy()
    {
        OnMobDeath = null;
    }
}

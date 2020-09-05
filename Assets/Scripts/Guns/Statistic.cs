using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Statistic
{
    [SerializeField] private string _name;
    [SerializeField] private List<StatisticLevel> _levels;

    public string Name => _name;

    public StatisticLevel CurrentLevel => _levels[Level];
    public StatisticLevel NextLevel => MaxLevel ? null : _levels[Level + 1];

    public int Level { get; private set; } = 0;
    public bool MaxLevel => Level >= _levels.Count - 1;

    public void Upgrade()
    {
        if (!MaxLevel)
        {
            Level++;
        }
    }

    public Statistic(Statistic statistic)
    {
        _name = statistic._name;
        _levels = new List<StatisticLevel>(statistic._levels);
    }
}

[System.Serializable]
public class StatisticLevel
{
    public float Value;
    public int UpgradeCost;
}

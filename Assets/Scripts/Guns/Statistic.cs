using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Statistic
{
    [SerializeField] private string _name;
    [SerializeField] private List<StatisticLevel> _levels;

    public string Name => _name;

    public StatisticLevel CurrentLevel;
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
}

public class StatisticLevel
{
    public float Value;
    public int UpgradeCost;
}

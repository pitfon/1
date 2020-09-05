using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData
{
    public string Name { get; private set; }

    public List<Statistic> Damage { get; private set; }
    public List<Statistic> FireRate { get; private set; }
    public List<Statistic> ReloadTime { get; private set; }
    public List<Statistic> Magazine { get; private set; }

    public float BulletSpeed { get; private set; }

    public GunData(GunInfo gunInfo)
    {
        Name = gunInfo.Name;

        Damage = new List<Statistic>(gunInfo.Damage);
        FireRate = new List<Statistic>(gunInfo.FireRate);
        ReloadTime = new List<Statistic>(gunInfo.ReloadTime);
        Magazine = new List<Statistic>(gunInfo.Magazine);
    }
}

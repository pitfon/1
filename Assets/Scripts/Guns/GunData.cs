using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData
{
    public string Name { get; private set; }

    public Statistic Damage { get; private set; }
    public Statistic FireRate { get; private set; }
    public Statistic ReloadTime { get; private set; }
    public Statistic Magazine { get; private set; }

    public float BulletSpeed { get; private set; }

    public GunData(GunInfo gunInfo)
    {
        Name = gunInfo.Name;

        Damage = new Statistic(gunInfo.Damage);
        FireRate = new Statistic(gunInfo.FireRate);
        ReloadTime = new Statistic(gunInfo.ReloadTime);
        Magazine = new Statistic(gunInfo.Magazine);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunData
{
    public string Name { get; private set; }
    public Sprite Avatar { get; private set; }

    public Statistic Damage { get; private set; }
    public Statistic FireRate { get; private set; }
    public Statistic ReloadTime { get; private set; }
    public Statistic Magazine { get; private set; }

    public float BulletSpeed { get; private set; }
    public bool Autiomatic { get; private set; }
    public bool IsBought { get; private set; }
    public int Price { get; private set; }

    public GunData(GunInfo gunInfo)
    {
        Name = gunInfo.Name;
        Avatar = gunInfo.Avatar;

        Damage = new Statistic(gunInfo.Damage);
        FireRate = new Statistic(gunInfo.FireRate);
        ReloadTime = new Statistic(gunInfo.ReloadTime);
        Magazine = new Statistic(gunInfo.Magazine);

        BulletSpeed = gunInfo.BulletSpeed;
        Autiomatic = gunInfo.Automatic;

        Price = gunInfo.Price;
        IsBought = Price <= 0;
    }

    public void SetBought()
    {
        IsBought = true;
    }
}

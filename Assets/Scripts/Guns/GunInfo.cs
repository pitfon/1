﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gunInfo1", menuName = "GunInfo")]
public class GunInfo : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _avatar;

    [Space]
    [SerializeField] private Statistic _damage;
    [SerializeField] private Statistic _fireRate;
    [SerializeField] private Statistic _reloadTime;
    [SerializeField] private Statistic _magazine;

    [Space]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _automatic;

    [Space]
    [SerializeField] private int _price;

    public string Name => _name;
    public Sprite Avatar => _avatar;

    public Statistic Damage => _damage;
    public Statistic FireRate => _fireRate;
    public Statistic ReloadTime => _reloadTime;
    public Statistic Magazine => _magazine;

    public float BulletSpeed => _bulletSpeed;
    public bool Automatic => _automatic;

    public int Price => _price;

    public GunData GetGunData()
    {
        return new GunData(this);
    }
}

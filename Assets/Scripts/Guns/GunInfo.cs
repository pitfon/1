using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInfo : ScriptableObject
{
    [SerializeField] private string _name;

    [Space]
    [SerializeField] private List<Statistic> _damage;
    [SerializeField] private List<Statistic> _fireRate;
    [SerializeField] private List<Statistic> _reloadTime;
    [SerializeField] private List<Statistic> _magazine;

    [Space]
    [SerializeField] private float _bulletSpeed;

    public string Name => _name;
    public List<Statistic> Damage => _damage;
    public List<Statistic> FireRate => _fireRate;
    public List<Statistic> ReloadTime => _reloadTime;
    public List<Statistic> Magazine => _magazine;

    public float BulletSpeed => _bulletSpeed;

    public GunData GetGunData()
    {
        return new GunData(this);
    }
}

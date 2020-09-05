using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPosition;

    private PlayerReferences _playerReferences;

    public GunData CurrentGun { get; private set; }

    public int Ammo { get; private set; }

    public float ShotCounter { get; private set; }
    public float ReloadTime { get; private set; }

    private AudioSource _audioSource;

    [SerializeField] private KeyCode shoot;
    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Init(PlayerReferences playerReferences)
    {
        _playerReferences = playerReferences;

        CurrentGun = playerReferences.PlayerData.GetCurrentGunData();
        Ammo = (int)CurrentGun.Magazine.CurrentLevel.Value;
    }

    private void Update()
    {
        if (Ammo <= 0)
        {
            ReloadTime -= Time.deltaTime;
            if (ReloadTime <= 0)
            {
                Ammo = (int)CurrentGun.Magazine.CurrentLevel.Value;
                ReloadTime = CurrentGun.ReloadTime.CurrentLevel.Value;
                ShotCounter = 0;
            }
        }
        else
        {
            ShotCounter -= Time.deltaTime;
            if (ShotCounter <= 0 && (Input.GetKeyDown(shoot) || (Input.GetKey(shoot) && CurrentGun.Autiomatic)))
            {
                ShotCounter = CurrentGun.FireRate.CurrentLevel.Value;
                Bullet newBullet = Instantiate(_bulletPrefab) as Bullet;
                newBullet.transform.position = _shootPosition.position;
                newBullet.transform.localRotation = Quaternion.identity;
                newBullet.Init(_playerReferences);
                _audioSource.Play();

                Ammo--;
            }
        }
    }
}

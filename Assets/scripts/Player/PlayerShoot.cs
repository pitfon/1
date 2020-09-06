using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private KeyCode shoot;

    protected PlayerReferences _playerReferences;

    public GunData CurrentGun { get; protected set; }

    public int Ammo { get; protected set; }

    public float ShotCounter { get; private set; }
    public float ReloadTime { get; private set; }

    public KeyCode Shoot => shoot;

    private AudioSource _audioSource;

    public System.Action<float> Progress;

    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Init(PlayerReferences playerReferences)
    {
        _playerReferences = playerReferences;

        CurrentGun = playerReferences.PlayerData.GetCurrentGunData();
        Ammo = (int)CurrentGun.Magazine.CurrentLevel.Value;

        Progress?.Invoke(1);
    }

    private void Update()
    {
        if (Ammo <= 0)
        {
            ReloadTime += Time.deltaTime;
            Progress?.Invoke(ReloadTime / CurrentGun.ReloadTime.CurrentLevel.Value);
            if (ReloadTime >= CurrentGun.ReloadTime.CurrentLevel.Value)
            {
                Ammo = (int)CurrentGun.Magazine.CurrentLevel.Value;
                ReloadTime = 0;
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
                newBullet.Init(_playerReferences, CurrentGun);
                _audioSource.Play();

                Ammo--;
                Progress?.Invoke(Ammo / CurrentGun.Magazine.CurrentLevel.Value);
            }
        }
    }
}

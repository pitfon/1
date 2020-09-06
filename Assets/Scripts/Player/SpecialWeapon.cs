using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : PlayerShoot
{
    public void Init(PlayerReferences playerReferences, GunData specialGun)
    {
        _playerReferences = playerReferences;

        CurrentGun = specialGun;
        Ammo = (int)CurrentGun.Magazine.CurrentLevel.Value;

        Progress?.Invoke(1);
    }
}

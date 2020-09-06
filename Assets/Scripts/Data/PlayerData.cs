using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public readonly string Name;
    public readonly int LookID;

    public int Money { get; private set; } = 100000;
    public int Health { get; private set; } = 100;
    public int Armor { get; private set; } = 0;

    public List<GunData> Guns { get; private set; }
    public string CurrentGunName { get; private set; }

    public System.Action OnMoneyAmountChange;
    public System.Action OnGunChange;

    public PlayerData(string name, int lookID)
    {
        Name = name;
        LookID = lookID;

        Guns = GunsManager.Instance.GetGuns();
        CurrentGunName = Guns.Find(x => x.IsBought).Name;
    }

    public bool HasMoney(int value)
    {
        return Money - value > 0;
    }

    public bool UpdateMoney(int value)
    {
        if (!HasMoney(-value))
        {
            return false;
        }

        Money += value;
        OnMoneyAmountChange?.Invoke();
        return true;
    }

    public void ChangeGun(string gunName)
    {
        if (CurrentGunName != gunName)
        {
            CurrentGunName = gunName;
            OnGunChange?.Invoke();
        }
    }

    public GunData GetCurrentGunData()
    {
        return Guns.Find(x => x.Name == CurrentGunName);
    }
}

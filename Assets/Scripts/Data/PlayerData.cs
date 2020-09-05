﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public readonly string Name;
    public readonly int LookID;

    public int Money { get; private set; } = 100;
    public int Health { get; private set; } = 100;
    public int Armor { get; private set; } = 0;

    public System.Action OnMoneyAmountChange;

    public PlayerData(string name, int lookID)
    {
        Name = name;
        LookID = lookID;
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
}

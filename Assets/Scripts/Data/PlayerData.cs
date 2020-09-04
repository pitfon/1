using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public readonly string Name;

    public int Money { get; private set; } = 100;

    public PlayerData(string name)
    {
        Name = name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameData
{
    public int Level { get; private set; } = 1;

    public void UpgradeLevel()
    {
        Level++;
    }
}

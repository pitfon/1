using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class GunInfo : ScriptableObject
{
    public string GunName;
    public SpriteChoose Sprites;

    public List<Statistic> FireRate;

    public int MagazineCapacity;
    public int MagazineCapacityCost;

    public float ReloadTime;
    public int ReloadTimeCost;

    public float BulletSpeed;
}

public class GunData
{
    public readonly string Name;
    public int FireRateLvl  = 0;
}
[System.Serializable]
public class SpriteChoose
{ 

    public Sprite Front;
    public Sprite Back;
    public Sprite Left;
    public Sprite Right;

    //public Sprite GetSprite(Vector3 direction)
    //{
     //   if (direction.z == -1)
     //   {

        //}
    //}

}
public struct Statistic
{
    public float Value;
    public int UpgradeCost;
}
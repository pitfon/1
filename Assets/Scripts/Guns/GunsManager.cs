using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManager : MonoBehaviour
{
    public static GunsManager Instance;
    private void Awake() { Instance = this; }

    [SerializeField] private List<GunInfo> _guns;
    [SerializeField] private List<GunInfo> _specialGuns;

    public List<GunData> GetGuns()
    {
        List<GunData> guns = new List<GunData>();
        for (int i = 0; i < _guns.Count; i++)
        {
            guns.Add(_guns[i].GetGunData());
        }
        return guns;
    }

    public List<GunData> GetSpecialGuns()
    {
        List<GunData> specialGuns = new List<GunData>();
        for (int i = 0; i < _specialGuns.Count; i++)
        {
            specialGuns.Add(_specialGuns[i].GetGunData());
        }
        return specialGuns;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public PlayerController PlayerController { get; private set; }
    public Health Health { get; private set; }
    public CharacterLookController LookController { get; private set; }
    public PlayerShoot PlayerShoot { get; private set; }

    public List<SpecialWeapon> SpecialWeapons { get; private set; }

    public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        Health = GetComponent<Health>();
        LookController = GetComponent<CharacterLookController>();
        PlayerShoot = GetComponent<PlayerShoot>();
        SpecialWeapons = new List<SpecialWeapon>(GetComponents<SpecialWeapon>());
    }

    public void Init(PlayerData data)
    {
        PlayerData = data;

        Health.Init(this);
        PlayerShoot.Init(this);

        for (int i = 0; i < SpecialWeapons.Count; i++)
        {
            if (i < data.SpecialGuns.Count)
            {
                SpecialWeapons[i].Init(this, data.SpecialGuns[i]);
            }
        }
    }
}

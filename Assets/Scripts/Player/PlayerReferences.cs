using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferences : MonoBehaviour
{
    public PlayerController PlayerController { get; private set; }
    public Health Health { get; private set; }
    public CharacterLookController LookController { get; private set; }

    public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        Health = GetComponent<Health>();
        LookController = GetComponent<CharacterLookController>();
    }

    public void Init(PlayerData data)
    {
        PlayerData = data;

        Health.Init(this);
    }
}

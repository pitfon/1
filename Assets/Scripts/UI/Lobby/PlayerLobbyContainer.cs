using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyContainer : MonoBehaviour
{
    [SerializeField] private PlayerInfoLobbyView _playerInfoLobbyView;

    public void Init(PlayerData data)
    {
        _playerInfoLobbyView.Init(data);
    }
}

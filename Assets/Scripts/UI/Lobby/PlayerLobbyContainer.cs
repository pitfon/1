using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyContainer : MonoBehaviour
{
    [SerializeField] private PlayerInfoLobbyView _playerInfoLobbyView;
    [SerializeField] private List<WeaponLobbyView> _weaponLobbyView;

    public void Init(PlayerData data)
    {
        _playerInfoLobbyView.Init(data);

        for (int i = 0; i < _weaponLobbyView.Count; i++)
        {
            if (i < data.Guns.Count)
            {
                _weaponLobbyView[i].gameObject.SetActive(true);
                _weaponLobbyView[i].Init(data, data.Guns[i]);
            }
            else
            {
                _weaponLobbyView[i].gameObject.SetActive(false);
            }
        }
    }
}

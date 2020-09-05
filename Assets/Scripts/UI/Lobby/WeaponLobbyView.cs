using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLobbyView : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _gunNameText;
    [SerializeField] private Image _gunAvatar;
    [SerializeField] private List<StatisticBox> _boxes;

    public void Init(PlayerData data, GunData gun)
    {
        _gunNameText.text = gun.Name;

        _boxes[0].Init(data, gun.Damage);
        _boxes[1].Init(data, gun.FireRate);
        _boxes[2].Init(data, gun.Magazine);
        _boxes[3].Init(data, gun.ReloadTime);
    }
}

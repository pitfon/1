using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLobbyView : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private TMPro.TextMeshProUGUI _gunNameText;
    [SerializeField] private Image _gunAvatar;

    [Header("Wear")]
    [SerializeField] private Button _wearButton;
    [SerializeField] private GameObject _wearFrame;

    [Header("BuyPanel")]
    [SerializeField] private GameObject _buyPanel;
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMPro.TextMeshProUGUI _buyPriceText;
    [SerializeField] private GameObject _lock;

    [Header("UpgradePanel")]
    [SerializeField] private GameObject _upgradePanel;
    [SerializeField] private List<StatisticBox> _boxes;

    private GunData _gun;
    private PlayerData _data;

    public void Init(PlayerData data, GunData gun)
    {
        _gun = gun;
        _data = data;
        _gunAvatar.sprite = gun.Avatar;
        _gunAvatar.SetNativeSize();

        _gunNameText.text = gun.Name;

        _buyButton.onClick.AddListener(Buy);
        _buyPriceText.text = $"${_gun.Price}";

        _boxes[0].Init(data, gun.Damage);
        _boxes[1].Init(data, gun.FireRate);
        _boxes[2].Init(data, gun.Magazine);
        _boxes[3].Init(data, gun.ReloadTime);

        _data.OnGunChange += CheckIsCurrentGun;
        _wearButton.onClick.AddListener(SetAsCurrentGun);

        CheckIsCurrentGun();
        CheckPanels();
    }

    private void CheckPanels()
    {
        _lock.SetActive(!_gun.IsBought);
        _buyPanel.SetActive(!_gun.IsBought);
        _upgradePanel.SetActive(_gun.IsBought);

        _wearButton.interactable = _gun.IsBought;
    }

    private void Buy()
    {
        if (!_gun.IsBought)
        {
            if (_data.UpdateMoney(-_gun.Price))
            {
                _gun.SetBought();
                CheckPanels();
            }
        }
    }

    private void SetAsCurrentGun()
    {
        if (_gun.IsBought)
        {
            _data.ChangeGun(_gun.Name);
        }
    }

    private void CheckIsCurrentGun()
    {
        _wearFrame.SetActive(_data.CurrentGunName == _gun.Name);
    }
}

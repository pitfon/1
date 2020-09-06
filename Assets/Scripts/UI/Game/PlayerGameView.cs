using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameView : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TMPro.TextMeshProUGUI _nameText;
    [SerializeField] private TMPro.TextMeshProUGUI _moneyText;

    [Space]
    [SerializeField] private Image _healthBar;

    [Space]
    [SerializeField] private PlayerMovementUI _movementUI;

    [Space]
    [SerializeField] private List<PlayerGunProgressUI> _gunProgress;

    private PlayerReferences _playerReferences;

    public void Init(PlayerReferences playerReferences)
    {
        _playerReferences = playerReferences;
        _movementUI.Init(playerReferences);

        _avatar.sprite = playerReferences.LookController.CurrentProfile.Avatar;
        _avatar.SetNativeSize();

        _nameText.text = playerReferences.PlayerData.Name;
        _playerReferences.PlayerData.OnMoneyAmountChange += UpdateMoneyText;

        _playerReferences.Health.OnCurrentHealthChanged += UpdateHealthBar;

        _gunProgress[0].Init(playerReferences.PlayerShoot);
        _gunProgress[1].Init(playerReferences.SpecialWeapons[0]);
        _gunProgress[2].Init(playerReferences.SpecialWeapons[1]);

        UpdateMoneyText();
        UpdateHealthBar();
    }

    private void UpdateMoneyText()
    {
        _moneyText.text = $"${_playerReferences.PlayerData.Money}";
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = _playerReferences.Health.CurrentHealth / _playerReferences.Health.MaxHealth;
    }

    private void OnDestroy()
    {
        _playerReferences.PlayerData.OnMoneyAmountChange -= UpdateMoneyText;
        _playerReferences.Health.OnCurrentHealthChanged -= UpdateHealthBar;
    }
}

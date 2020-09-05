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

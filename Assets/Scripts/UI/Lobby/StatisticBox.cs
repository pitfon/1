using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticBox : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _nameText;
    [SerializeField] private TMPro.TextMeshProUGUI _valueText;

    [Space]
    [SerializeField] private TMPro.TextMeshProUGUI _upgradeCostText;
    [SerializeField] private Button _upgradeButton;

    private PlayerData _data;
    private Statistic _statistic;

    public System.Action OnUpgrade;

    public void Init(PlayerData data, Statistic statistic)
    {
        _data = data;
        _statistic = statistic;

        _data.OnMoneyAmountChange += CheckUpgradeButton;

        _nameText.text = statistic.Name;
        _valueText.text = statistic.CurrentLevel.Value.ToString();

        CheckUpgradeButton();
    }

    private void Start()
    {
        _upgradeButton.onClick.AddListener(Upgrade);
    }

    private void CheckUpgradeButton()
    {
        _upgradeButton.interactable = !_statistic.MaxLevel && _data.HasMoney(_statistic.NextLevel.UpgradeCost);
        _upgradeCostText.text = !_statistic.MaxLevel ? $"${_statistic.NextLevel.UpgradeCost}" : "MAX LEVEL";
    }

    public void Upgrade()
    {
        if (_data.UpdateMoney(-_statistic.NextLevel.UpgradeCost))
        {
            _statistic.Upgrade();
            CheckUpgradeButton();
            _valueText.text = _statistic.CurrentLevel.Value.ToString();
        }
    }
}

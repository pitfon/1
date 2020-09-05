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

    public System.Action OnUpgrade;

    public void Init(string name, string value, string upgradeCost)
    {
        _nameText.text = name;
        _valueText.text = value;
        _upgradeCostText.text = upgradeCost;
    }

    private void Start()
    {
        _upgradeButton.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        OnUpgrade?.Invoke();
    }
}

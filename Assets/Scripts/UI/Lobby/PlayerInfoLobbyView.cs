using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoLobbyView : MonoBehaviour
{
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private PlayerData _data;

    public void Init(PlayerData data)
    {
        _data = data;
        data.OnMoneyAmountChange += UpdateMoneyText;

        UpdateInfoTexts();
        UpdateMoneyText();
    }

    private void UpdateInfoTexts()
    {
        _avatar.sprite = CharacterLooksHolder.Instance.GetLookAvatar(_data.LookID);
        _avatar.SetNativeSize();

        _nameText.text = _data.Name;
    }

    private void UpdateMoneyText()
    {
        _moneyText.text = $"${_data.Money}";
    }

    private void OnDestroy()
    {
        _data.OnMoneyAmountChange -= UpdateMoneyText;
    }
}

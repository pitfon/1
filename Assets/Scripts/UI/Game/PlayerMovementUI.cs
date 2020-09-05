using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _upText;
    [SerializeField] private TMPro.TextMeshProUGUI _downText;
    [SerializeField] private TMPro.TextMeshProUGUI _leftText;
    [SerializeField] private TMPro.TextMeshProUGUI _rightText;
    [SerializeField] private TMPro.TextMeshProUGUI _shiftText;

    public void Init(PlayerReferences playerReferences)
    {
        _upText.text = playerReferences.PlayerController.Up.ToString();
        _downText.text = playerReferences.PlayerController.Down.ToString();
        _leftText.text = playerReferences.PlayerController.Left.ToString();
        _rightText.text = playerReferences.PlayerController.Right.ToString();
        _shiftText.text = playerReferences.PlayerController.Shift.ToString();
    }
}

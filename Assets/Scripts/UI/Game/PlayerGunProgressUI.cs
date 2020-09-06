using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGunProgressUI : MonoBehaviour
{
    [SerializeField] private Image _gunAvatar;
    [SerializeField] private Image _progressBar;
    [SerializeField] private GameObject _fullProgress;
    [SerializeField] private TMPro.TextMeshProUGUI _keyText;

    public void Init(PlayerShoot playerShoot)
    {
        _gunAvatar.sprite = playerShoot.CurrentGun.Avatar;
        _gunAvatar.SetNativeSize();
        _keyText.text = playerShoot.Shoot.ToString();

        playerShoot.Progress += UpdateUI;

        UpdateUI(1);
    }

    private void UpdateUI(float progress)
    {
        _progressBar.fillAmount = progress;
        _fullProgress.SetActive(progress >= 1.0f);
    }
}

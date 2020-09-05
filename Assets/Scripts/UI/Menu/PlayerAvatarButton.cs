using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatarButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image _image;

    private Button _button;

    private int _id;
    private PlayerInfoMenuView _playerInfoView;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(PlayerInfoMenuView playerInfoView, int ID)
    {
        _id = ID;
        _playerInfoView = playerInfoView;

        _button.onClick.AddListener(SetID);

        _image.sprite = CharacterLooksHolder.Instance.GetLook(ID);
        _image.SetNativeSize();

        PlayerInfoMenuView.OnAvatarIDChanged += CheckInterectable;
    }

    private void SetID()
    {
        _playerInfoView.SetAvatarID(_id);
    }

    private void CheckInterectable(int prev, int next)
    {
        if (prev == _id)
        {
            _button.interactable = true;
        }
        else if (next == _id)
        {
            _button.interactable = false;
        }
    }

    protected void OnDestroy()
    {
        PlayerInfoMenuView.OnAvatarIDChanged -= CheckInterectable;
    }
}

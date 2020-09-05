using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoMenuView : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField _nameInputField;
    [SerializeField] private Image _playerAvatar;

    [Space]
    [SerializeField] private List<PlayerAvatarButton> _avatarButtons;

    public int AvatarID { get; private set; } = -1;
    public string Name => _nameInputField.text;

    public bool IsReady { get; private set; }

    public static System.Action<int, int> OnAvatarIDChanged;
    public System.Action OnStateChanged;

    public void Init(int id)
    {
        for (int i = 0; i < _avatarButtons.Count; i++)
        {
            if (i < CharacterLooksHolder.Instance.Looks.Count)
            {
                _avatarButtons[i].gameObject.SetActive(true);
                _avatarButtons[i].Init(this, i);
            }
            else
            {
                _avatarButtons[i].gameObject.SetActive(false);
            }
        }

        _nameInputField.onValueChanged.AddListener(OnValueChangedListener);

        SetAvatarID(id);
    }

    public void SetAvatarID(int id)
    {
        if (id != AvatarID)
        {
            int prevID = AvatarID;
            AvatarID = id;

            _playerAvatar.sprite = CharacterLooksHolder.Instance.GetLook(id);
            _playerAvatar.SetNativeSize();

            OnAvatarIDChanged?.Invoke(prevID, AvatarID);
        }
    }

    private void OnValueChangedListener(string value)
    {
        bool wasReady = IsReady;
        IsReady = !string.IsNullOrEmpty(value);

        if (IsReady != wasReady)
        {
            OnStateChanged?.Invoke();
        }
    }
}

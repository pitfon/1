using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLooksHolder : MonoBehaviour
{
    public static CharacterLooksHolder Instance;
    private void Awake() { Instance = this; }

    [SerializeField] private List<CharacterLookProfile> _looks;

    public List<CharacterLookProfile> Looks => _looks;

    public Sprite GetLookAvatar(int id)
    {
        return _looks[id].Avatar;
    }

    public CharacterLookProfile GetLookProfile(int id)
    {
        return _looks[id];
    }
}

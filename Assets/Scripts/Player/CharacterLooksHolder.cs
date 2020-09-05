using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLooksHolder : MonoBehaviour
{
    public static CharacterLooksHolder Instance;
    private void Awake() { Instance = this; }

    [SerializeField] private List<Sprite> _looks;

    public List<Sprite> Looks => _looks;

    public Sprite GetLook(int id)
    {
        return _looks[id];
    }
}

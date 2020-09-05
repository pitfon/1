using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLooksHolder : MonoBehaviour
{
    [SerializeField] private List<Sprite> _looks;

    public Sprite GetLook(int id)
    {
        return _looks[id];
    }
}

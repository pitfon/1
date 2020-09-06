using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;

    [SerializeField] private float _value;
    public float Value => _value;

    [SerializeField] private float _dropChance;
    public float DropChance => _dropChance;//eg. 0.1

    [SerializeField] private GameObject _Prefab;
    public GameObject Prefab => _Prefab;
}

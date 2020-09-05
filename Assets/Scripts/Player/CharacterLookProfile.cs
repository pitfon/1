using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "lookProfile1", menuName = "LookProfile")]
public class CharacterLookProfile : ScriptableObject
{
    [SerializeField] private float _delay;

    [Space]
    [SerializeField] private Sprite _avatar;

    [Space]
    [SerializeField] private List<Sprite> _moveUp;
    [SerializeField] private List<Sprite> _moveDown;
    [SerializeField] private List<Sprite> _moveLeft;

    public float Delay => _delay;

    public Sprite Avatar => _avatar;

    public List<Sprite> MoveUp => _moveUp;
    public List<Sprite> MoveDown => _moveDown;
    public List<Sprite> MoveLeft => _moveLeft;
}

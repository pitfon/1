using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CharacterLookProfile _characterLookProfile;

    private LookDirection _up;
    private LookDirection _down;
    private LookDirection _left;
    private LookDirection _right;

    private CharacterLookProfile _currentProfile;
    private LookDirection _currentLookDirection = null;

    private Coroutine _coroutine;

    private float _time;

    private void Start()
    {
        if (_characterLookProfile != null)
        {
            InitProfile(_characterLookProfile);
        }
    }

    public void UpdateDirection(Vector3 direction)
    {
        LookDirection prevLookDirection = _currentLookDirection;

        if (direction.y > 0)
        {
            _currentLookDirection = _up;
        }
        else if (direction.y < 0)
        {
            _currentLookDirection = _down;
        }
        else if (direction.x > 0)
        {
            _currentLookDirection = _right;
        }
        else if (direction.x < 0)
        {
            _currentLookDirection = _left;
        }
        else
        {
            _currentLookDirection = _down;
        }

        if (prevLookDirection != _currentLookDirection)
        {
            _time = 0;

            Debug.Log($"{direction} - {_currentLookDirection.Update(false).name}");
        }

        _spriteRenderer.flipX = _currentLookDirection.FlipX;
        _spriteRenderer.sprite = _currentLookDirection.Update(false);
    }

    public void InitProfile(CharacterLookProfile lookProfile)
    {
        if (_coroutine != null) { StopCoroutine(_coroutine); }

        _currentProfile = lookProfile;

        _up = new LookDirection(lookProfile.MoveUp, false);
        _down = new LookDirection(lookProfile.MoveDown, false);
        _left = new LookDirection(lookProfile.MoveLeft, false);
        _right = new LookDirection(lookProfile.MoveLeft, true);

        _currentLookDirection = _down;

        //_coroutine = StartCoroutine(UpdateLook());
    }

    private IEnumerator UpdateLook()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        _time = 0;

        while (true)
        {
            yield return wait;
            _time += Time.deltaTime;

            if (_time > _currentProfile.Delay)
            {
                _time = 0;
                _spriteRenderer.sprite = _currentLookDirection.Update(true);
            }
        }
    }
}

public class LookDirection
{
    private List<Sprite> _sprites;
    private int _index;
    public bool FlipX { get; private set; }

    public LookDirection(List<Sprite> sprites, bool flipX)
    {
        FlipX = flipX;
        _sprites = new List<Sprite>(sprites);
        _index = sprites.Count;
    }

    public Sprite Update(bool increase)
    {
        if (increase) { _index++; }
        if (_index >= _sprites.Count) { _index = 0; }

        return _sprites[_index];
    }
}
using UnityEngine;
using System.Collections;

public class Saboteur : AI_Base
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _radius;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
        base.Attack();
        
        if(_player1Dist <= _radius)
        {
            _gameController.Player1.Health.Damage(_attackDamage);
        }
        if (_player2Dist <= _radius)
        {
            _gameController.Player2.Health.Damage(_attackDamage);
        }

        gameObject.SetActive(false);
    }
}
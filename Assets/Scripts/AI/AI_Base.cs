using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI_Base : MonoBehaviour
{
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _attackCooldown = 1.0f;
    [SerializeField] protected int _attackDamage;

    protected float _attackTimer;
    protected NavMeshAgent _agent;
    protected GameController _gameController;

    protected Health _target;

    protected float _player1Dist, _player2Dist;
    protected Health _player1Health, _player2Health;


    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _gameController = GameController.Instance;

        _player1Health = _gameController.Player1.Health;
        _player2Health = _gameController.Player2.Health;
    }

    protected virtual void Update()
    {
        _player1Dist = Vector3.Distance(transform.position, _player1Health.transform.position);
        _player2Dist = Vector3.Distance(transform.position, _player2Health.transform.position);
        _target = SelectTarget();

        _agent.SetDestination(_target.transform.position);

        if (_agent.remainingDistance <= _attackRange && _agent.remainingDistance > 0)
        {
            if (_attackTimer <= 0)
            {
                Attack();
                _attackTimer = _attackCooldown;
            }
        }
        _attackTimer -= Time.deltaTime;
    }

    protected virtual void Attack()
    {

    }

    private Health SelectTarget()
    {
        if (_player1Health.Alive && _player2Health.Alive)
        {
            if (_player1Dist > _player2Dist)
                return _player2Health;

            return _player1Health;
        }
        else
        {
            if (_player1Health.Alive)
                return _player1Health;
            else if (_player2Health.Alive)
                return _player2Health;
            else
                return null;

        }
    }
}

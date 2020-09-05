using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI_Base : MonoBehaviour
{
    [SerializeField] protected float _attackRange;
    [SerializeField] protected float _attackCooldown = 1.0f;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected Transform _target;

    protected float _attackTimer;
    protected NavMeshAgent _agent;


    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

    }

    protected virtual void Update()
    {
        //temp   
        _agent.SetDestination(_target.position);

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
}

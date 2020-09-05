using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI_Base : MonoBehaviour
{
    [SerializeField] private Transform _target;
    NavMeshAgent _agent;


    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        //temp
        _agent.SetDestination(_target.position);
    }
}

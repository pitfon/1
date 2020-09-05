using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Base : MonoBehaviour
{
    [SerializeField] private Transform _target;
    NavMeshAgent _agent;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //temp
        _agent.SetDestination(_target.position);
    }
}

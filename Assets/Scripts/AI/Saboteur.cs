using UnityEngine;
using System.Collections;

public class Saboteur : AI_Base
{
    [SerializeField] private GameObject _explosion;

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

        gameObject.SetActive(false);
    }
}
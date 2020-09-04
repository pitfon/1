using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    [SerializeField] private KeyCode _left;
    [SerializeField] private KeyCode _right;
    [SerializeField] private KeyCode _shift;
    private float _horizontalVel;
    private float _verticalVel;
    private float _speed = 5;
    private float _runSpeed = 2;
    private int _vert;
    private int _hor;
    [SerializeField]
    Rigidbody2D rb;
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(_up))
        {
            _vert = 1;
        }
        if (Input.GetKey(_down))
        {
            _vert = -1;
        }
        if (!Input.GetKey(_down) && !Input.GetKey(_up))
        {
            _vert = 0;
        }
        if (Input.GetKey(_left))
        {
            _hor = -1;
        }
        if (Input.GetKey(_right))
        {
            _hor = 1;
        }
        if (!Input.GetKey(_left) && !Input.GetKey(_right))
        {
            _hor = 0;
        }

        if (Input.GetKeyDown(_shift))
        {
            _speed = _speed * _runSpeed;
        }
        if (Input.GetKeyUp(_shift))
        {
            _speed = _speed / _runSpeed;
        }
        rb.velocity = new Vector2(_speed * _hor, _speed * _vert);
        print(_vert);
        print(rb.velocity);
    }
}

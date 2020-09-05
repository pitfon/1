using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    private int _dirhor;
    private int _dirver;
    Vector3 _checkPos;
    private bool _isMoving;
    [SerializeField]
    Rigidbody2D rb;

    public Vector2 direction;
    private void Start()
    {
        _dirhor = 1;
        _dirver = 1;
    }
    private void Update()
    {
        Movement();
        if(!Input.GetKey(_up)&&!Input.GetKey(_down))
        {
            _dirver = 0;

        }
        if(!Input.GetKey(_left) && !Input.GetKey(_right))
        {
            _dirhor = 0;
        }
    }



    private void Movement()
    {
        if (Input.GetKey(_up))
        {
            _vert = 1;
            _dirver = 1;
        }
        if (Input.GetKey(_down))
        {
            _vert = -1;
            _dirver = -1;
        }
        if (!Input.GetKey(_down) && !Input.GetKey(_up))
        {
            _vert = 0;
        }
        if (Input.GetKey(_left))
        {
            _hor = -1;
            _dirhor = -1;
        }
        if (Input.GetKey(_right))
        {
            _hor = 1;
            _dirhor = 1;
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

        direction = new Vector2(_dirhor, _dirver);
        rb.velocity = new Vector2(_speed * _hor, _speed * _vert);
    }
}

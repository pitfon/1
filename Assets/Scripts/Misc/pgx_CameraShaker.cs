﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pgx_CameraShaker : MonoBehaviour
{
    public bool _constantShake = false;
    public float shakeSpeed = 10.0f;
    public float shakeDecay = 5.0f;
    public float shakeAmplitude = 0.0f;
    Vector2 shake;

	void Start ()
    {

    }
	
    public void AddShake(float amount)
    {
        shakeAmplitude = amount;
    }

	void Update ()
    {
        if(!_constantShake)
            shakeAmplitude = Mathf.SmoothStep(shakeAmplitude, 0.0f, Time.deltaTime * shakeDecay);

        float bx = (Mathf.PerlinNoise(0, Time.time * shakeSpeed) - 0.5f);
        float by = (Mathf.PerlinNoise(0, (Time.time * shakeSpeed) + 100)) - 0.5f;

        bx *= shakeAmplitude;
        by *= shakeAmplitude;

        shake = new Vector2(bx, by);
        transform.localPosition = new Vector3(shake.x, shake.y, shake.magnitude);
    }
}

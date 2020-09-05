using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotationNormalizer : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(_rotation);
    }
}

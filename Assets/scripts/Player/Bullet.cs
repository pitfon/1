using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=15;
    Rigidbody rb;
    public Vector3 _direction;
    float destroyTime = 5;
    float lifeTime = 0;
    public void Init(PlayerController controller)
    {
    _direction = controller.direction;
        rb=GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.Translate(_direction * speed*Time.deltaTime);
        lifeTime += Time.deltaTime;


        if (lifeTime > destroyTime)
        {
           Destroy(gameObject);
        }
    }
}

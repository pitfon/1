using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private KeyCode shoot;
    public float speed=15;
    public Vector3 _direction;
    float destroyTime = 5;
    float lifeTime = 0;
    public void Init(PlayerController controller)
    {
    _direction = controller.direction;
    }
    private void Update()
    {
        print(_direction);
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.Translate(_direction * speed * Time.deltaTime);


        lifeTime += Time.deltaTime;
        if (lifeTime > destroyTime)
        {
           Destroy(gameObject);
        }
    }
}

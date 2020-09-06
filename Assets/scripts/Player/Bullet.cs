using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerReferences PlayerReferences { get; private set; }

    private float _speed = 15;
    private Vector3 _direction;

    float _destroyTime = 5;

    public void Init(PlayerReferences playerReferences)
    {
        PlayerReferences = playerReferences;

        _speed = playerReferences.PlayerShoot.CurrentGun.BulletSpeed;
        _direction = playerReferences.PlayerController.direction;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        transform.Translate(_direction * _speed * Time.deltaTime);

        _destroyTime -= Time.deltaTime;
        if (_destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnterListener(other);
    }

    protected virtual void OnTriggerEnterListener(Collider other)
    {
        AI_Base aiBase = other.GetComponent<AI_Base>();
        if (aiBase)
        {
            aiBase.GetComponent<Health>().Damage((int)PlayerReferences.PlayerShoot.CurrentGun.Damage.CurrentLevel.Value);
        }

        Destroy(gameObject);
    }
}

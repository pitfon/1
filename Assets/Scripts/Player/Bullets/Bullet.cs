using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerReferences PlayerReferences { get; private set; }
    protected GunData _gun;

    protected float _speed = 15;
    protected Vector3 _direction;

    float _destroyTime = 5;

    public void Init(PlayerReferences playerReferences, GunData gun)
    {
        PlayerReferences = playerReferences;
        _gun = gun;

        _speed = playerReferences.PlayerShoot.CurrentGun.BulletSpeed;
        _direction = playerReferences.PlayerController.direction;
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    protected virtual void Update()
    {
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
            aiBase.GetComponent<Health>().Damage((int)_gun.Damage.CurrentLevel.Value);
        }

        Destroy(gameObject);
    }
}

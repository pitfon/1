using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : Bullet
{
    [SerializeField] private Transform _torpedoRenderer;

    public override void Init(PlayerReferences playerReferences, GunData gun)
    {
        base.Init(playerReferences, gun);

        Vector3 rotation = Vector3.zero;
        if (_direction.y > 0)
        {
            rotation = new Vector3(0, 0, 90);
        }
        else if (_direction.y < 0)
        {
            rotation = new Vector3(0, 0, -90);
        }
        else if (_direction.x < 0)
        {
            rotation = new Vector3(0, 0, 180);
        }
        _torpedoRenderer.localRotation = Quaternion.Euler(rotation);
    }
}

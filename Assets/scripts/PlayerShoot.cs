using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool isFiring;

    public Bullet bullet;

    public float BulletSpeed;

    public float TimeBeetweenShots;
    public float ShotCounter;

    public Transform firePoint;

    [SerializeField] private KeyCode shoot;
    private void Update()
    {
        if (Input.GetKeyDown(shoot))
        {
            isFiring = true;
        }
        if (Input.GetKeyUp(shoot)) 
        {
            isFiring = false;
        }
        ShotCounter -= Time.deltaTime;
        if (Input.GetKeyDown(shoot))
        {
            if (ShotCounter <= 0)
            {
                ShotCounter = TimeBeetweenShots;
                Bullet newBullet = Instantiate(bullet, firePoint.position,firePoint.rotation) as Bullet;
                newBullet.speed = BulletSpeed;
            }
        }
        if (Input.GetKeyDown(shoot))
        {

        }  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool isFiring;
    PlayerController controller;

    public Bullet bullet;

    public float BulletSpeed;

    public float TimeBeetweenShots;
    public float ShotCounter;
    [SerializeField]
    public Transform ShootPosition;

    [SerializeField] private KeyCode shoot;
    public void Awake()
    {
        controller = GetComponent<PlayerController>();
    }
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
                Bullet newBullet = Instantiate(bullet, Vector3.zero, ShootPosition.rotation, ShootPosition) as Bullet;
                newBullet.transform.localPosition = Vector3.zero;
                newBullet.Init(controller);
            }
        }  
    }
}

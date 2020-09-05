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
                Bullet newBullet = Instantiate(bullet) as Bullet;
                newBullet.transform.position = ShootPosition.position;
                newBullet.transform.localRotation = Quaternion.identity;
                newBullet.transform.localRotation = Quaternion.Euler(90, 0, 0);
                newBullet.Init(controller);
            }
        }  
    }
}

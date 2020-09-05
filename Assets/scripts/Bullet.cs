using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private KeyCode shoot;
    public float speed=15;
    [SerializeField]
    PlayerController controller;
    GameObject character;
    private Vector2 direction;
    float destroyTime = 5;
    float lifeTime = 0;
    private void Awake()
    {
        character = GameObject.Find("Character");
        controller = character.GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(shoot))
        {
            direction = controller.direction;
        }
        transform.Translate(direction * speed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > destroyTime)
        {
           Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _lifetime = 1.0f;
    void Start()
    {
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        float timer = 0.0f;
        while(timer < _lifetime)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
        Destroy(gameObject);
    }
}

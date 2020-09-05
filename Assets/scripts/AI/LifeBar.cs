using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    float pt;
    [SerializeField]
    private Health health;
    private void Start()
    {
        health = transform.parent.GetComponent<Health>();
        health.OnCurrentHealthChanged += UpdateBar;
    }

    private void UpdateBar()
    {
        print(health.CurrentHealth);
        pt = health.CurrentHealth / 100;
        transform.localScale = new Vector3(pt, 0, 0);
    }

    private void OnDestroy()
    {
        health.OnCurrentHealthChanged -= UpdateBar;
    }
}

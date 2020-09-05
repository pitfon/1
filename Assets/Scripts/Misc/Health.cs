using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    protected int _currentHealth = 100;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0)) Damage(25);
    }

    public virtual void Damage(int damage)
    {
        _currentHealth -= damage;
        StartCoroutine(DamageFlash());
        if(_currentHealth <= 0)
        {
            Death();
        }
    }

    IEnumerator DamageFlash()
    {
        float fadeSpeed = 5.0f;
        float duration = 1.0f;
        float timer = 0;

        _spriteRenderer.color = Color.red;
        while(timer < duration)
        {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    protected virtual void Death()
    {
        gameObject.SetActive(false);
    }
}

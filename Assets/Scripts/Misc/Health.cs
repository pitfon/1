using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public float CurrentHealth { get; private set; } = 100;

    public System.Action OnCurrentHealthChanged;

    protected virtual void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == ("Bullet"))
        {
            print("hit");
            Damage(25);
        }
    }
    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0)) Damage(25);
    }
    public virtual void Damage(int damage)
    {
        CurrentHealth -= damage;
        StartCoroutine(DamageFlash());

        print(CurrentHealth);
        OnCurrentHealthChanged?.Invoke();
        

        OnCurrentHealthChanged?.Invoke();
        print(CurrentHealth);

        if(CurrentHealth <= 0)
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
        pgx_CameraShaker.Instance.AddShake(1);
    }

    
}

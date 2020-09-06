using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool Alive { get; private set; }

    [SerializeField] private SpriteRenderer _spriteRenderer;
    public float CurrentHealth { get; private set; } = 100;
    public float MaxHealth { get; private set; } = 100;

    public System.Action OnCurrentHealthChanged;
    public System.Action<Health> OnDeath;

    public void Init(PlayerReferences playerReferences)
    {
        MaxHealth = playerReferences.PlayerData.Health;
        CurrentHealth = playerReferences.PlayerData.Health;
        Alive = true;
    }

    public virtual void Damage(int damage)
    {
        CurrentHealth -= damage;
        StartCoroutine(DamageFlash());

        OnCurrentHealthChanged?.Invoke();

        if (CurrentHealth <= 0)
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
        while (timer < duration)
        {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * fadeSpeed);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public virtual void Death()
    {
        Alive = false;
        OnDeath?.Invoke(this);
        OnDeath = null;
        //pgx_CameraShaker.Instance.AddShake(1);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}

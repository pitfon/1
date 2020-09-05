﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public float CurrentHealth { get; private set; } = 100;
    public float MaxHealth { get; private set; } = 100;

    public System.Action OnCurrentHealthChanged;

    public void Init(PlayerReferences playerReferences)
    {
        MaxHealth = playerReferences.PlayerData.Health;
        CurrentHealth = playerReferences.PlayerData.Health;
    }

    public virtual void Damage(int damage)
    {
        CurrentHealth -= damage;
        StartCoroutine(DamageFlash());

        print(CurrentHealth);
        OnCurrentHealthChanged?.Invoke();


        OnCurrentHealthChanged?.Invoke();
        print(CurrentHealth);

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

    protected virtual void Death()
    {
        gameObject.SetActive(false);
        pgx_CameraShaker.Instance.AddShake(1);
    }


}

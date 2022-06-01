using UnityEngine;
using System.Collections.Generic;

public class PlayerController2D : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    public float healthRegenTime = 0f;
    public float maxStamina = 20f;
    public float currentStamina = 20f;
    public float staminaRegenTime = 2f;
    public float startingGems = 0.0f;

    protected EffectableObject Effectable;

    void Awake()
    {
        Effectable = GetComponent<EffectableObject>();
    }

    void FixedUpdate()
    {
        RegenHealth();
        RegenStamina();
        HealOverTime();
        CheckIfDead();
    }
    public void DoDamage(float damage)
    {
        currentHealth -= damage;
    } 
    public void DoHeal(float healValue)
    {
        if (currentHealth + healValue > maxHealth)
        {
            healValue = maxHealth - currentHealth;
        }
        currentHealth += healValue;
    }
    public void GemCollected(float gemCount)
    {
        startingGems += gemCount;
    }

    private void RegenHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegenTime * Time.fixedDeltaTime;
        }
    }

    private void RegenStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenTime * Time.fixedDeltaTime;
        }
    }

    private void HealOverTime()
    {
        float healPerSec = Effectable.Effect_HealPerSec(0);

        if (healPerSec > 0)
        {
            // TODO: healing animation
            DoHeal(healPerSec * Time.fixedDeltaTime);
        }
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            //TODO: death animation here
        }
    }
}
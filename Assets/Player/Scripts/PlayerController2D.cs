using UnityEngine;
using System.Collections.Generic;

public class PlayerController2D : MonoBehaviour
{
    public float startingGems = 0.0f;
    public float startingExp = 0.0f;
    protected EffectableObject Effectable;
    private PlayerStats playerStats;
    void Awake()
    {
        Effectable = GetComponent<EffectableObject>();
    }
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
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
        // has invincible status?
        if (!Effectable.Effect_IsInvincible(false) && !Effectable.Effect_IsDodging(false))
        {
            playerStats.currentHealth -= damage;
        }
    } 
    public void DoHeal(float healValue)
    {
        if (playerStats.currentHealth + healValue > playerStats.maxHealth)
        {
            healValue = playerStats.maxHealth - playerStats.currentHealth;
        }
        playerStats.currentHealth += healValue;
    }
    public void GemCollected(float gemCount)
    {
        startingGems += gemCount;
    }
    public void ExpCollected(float expCount)
    {
        startingExp += expCount;
    }

    private void RegenHealth()
    {
        if (playerStats.currentHealth < playerStats.maxHealth)
        {
            playerStats.currentHealth += playerStats.healthRegenTime * Time.fixedDeltaTime;
        }
    }

    private void RegenStamina()
    {
        if (playerStats.currentStamina < playerStats.maxStamina)
        {
            playerStats.currentStamina += playerStats.staminaRegenTime * Time.fixedDeltaTime;
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
        if (playerStats.currentHealth <= 0)
        {
            Time.timeScale = 0;
            //TODO: death animation here
        }
    }
}
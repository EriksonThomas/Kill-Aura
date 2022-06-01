using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : ScriptableObject
{
    [SerializeField] protected float duration = 0f;
    [SerializeField] protected bool permanent = false;
    public bool IsActive => (permanent || durationRemaining > 0f);
    public GameObject icon;
    float durationRemaining = 0f;

    public void EnableEffect()
    {
        durationRemaining = duration;
    }

    public void TickEffect()
    {
        if (permanent == false && durationRemaining > 0)
            durationRemaining -= Time.fixedDeltaTime;
    }

    public void OnEffectEnd()
    {
    }

    public virtual float Effect_HealPerSec(float originalHealPerSec)
    {
        return originalHealPerSec;
    }

    public virtual bool Effect_IsInvincible(bool originalInvincible)
    {
        return originalInvincible;
    }
}

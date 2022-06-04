using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectableObject : MonoBehaviour
{
    public List<BaseEffect> activeEffects = new List<BaseEffect>();
    public bool statusBarHasSeen = false; // TODO: change to list of pointers or something
    public bool statusSpriteHasSeen = false;

    void FixedUpdate()
    {
        // tick all active effects
        for(int index = activeEffects.Count - 1; index >= 0; --index)
        {
            activeEffects[index].TickEffect();

            // if effect finished
            if (!activeEffects[index].IsActive)
            {
                activeEffects[index].OnEffectEnd();
                activeEffects.RemoveAt(index);
                statusBarHasSeen = false;
                statusSpriteHasSeen = false;
            }
        }
    }

    public void ApplyEffect(BaseEffect effectTemplate)
    {
        // create a new instance of the effect
        var newEffect = ScriptableObject.Instantiate(effectTemplate);

        // make the effect active
        newEffect.EnableEffect();
        activeEffects.Add(newEffect);
        statusBarHasSeen = false;
        statusSpriteHasSeen = false;
    }

    public void RemoveAllOfEffect(BaseEffect effect)
    {
        // removes all instances of the given effect type
        for (int index = 0; index < activeEffects.Count; ++index)
        {
            if (activeEffects[index].GetType() == effect.GetType()) // TODO: check if this can be false (removes ALL effects)
            {
                activeEffects.RemoveAt(index);
                statusBarHasSeen = false;
                statusSpriteHasSeen = false;
            }
        }
    }

    public float Effect_HealPerSec(float originalHealPerSec)
    {
        float workingHOT = originalHealPerSec;

        for (int index = 0; index < activeEffects.Count; ++index)
        {
            if (activeEffects[index].IsActive)
            {
                workingHOT = activeEffects[index].Effect_HealPerSec(workingHOT);
            }
        }
        return workingHOT;
    }

    public bool Effect_IsInvincible(bool originalInvincible)
    {
        bool workingInvincible = originalInvincible;

        for (int index = 0; index < activeEffects.Count; ++index)
        {
            if (activeEffects[index].IsActive)
            {
                workingInvincible = activeEffects[index].Effect_IsInvincible(workingInvincible);
            }
        }
        return workingInvincible;
    }
}

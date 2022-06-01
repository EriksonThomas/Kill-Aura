using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Heal Over Time", fileName = "Effect_HealOverTime")]
public class Effect_HealOverTime : BaseEffect
{
    public float HealPerSecondModifier = 10f;
    public override float Effect_HealPerSec(float originalHealPerSec)
    {
        return originalHealPerSec + HealPerSecondModifier;
    }
}

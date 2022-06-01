using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Invincible", fileName = "Effect_Invincible")]
public class Effect_Invincible : BaseEffect
{
    public override bool Effect_IsInvincible(bool originalHealPerSec)
    {
        return true;
    }
}

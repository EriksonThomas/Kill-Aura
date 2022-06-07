using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Dodge", fileName = "Effect_Dodge")]
public class Effect_Dodge : BaseEffect
{
    public override bool Effect_IsInvincible(bool originalHealPerSec)
    {
        return true;
    }
    //speed up
    //translucent 
}

using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Dodge", fileName = "Effect_Dodge")]
public class Effect_Dodge : BaseEffect
{
    public override bool Effect_IsDodging(bool originalDodging)
    {
        return true;
    }
    
    //speed up
    //translucent
    //collision off
}

using UnityEngine;
public class AbilityManager : MonoBehaviour
{
    private float timer = 0;
    public LightningAttack lightningScript;
    void Start()
    {
        if(lightningScript.lightningStrike == true)
        {
            InvokeRepeating("CallAttack", 1f, lightningScript.lightningInterval);
        }
    }
    void CallAttack()
    {
        lightningScript.LightningStrikeAttack();
    }
}
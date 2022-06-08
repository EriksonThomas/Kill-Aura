 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using System;
using System.Collections.Generic;
 
public class GlobalTimer : MonoBehaviour
{
    private static Dictionary<string, double> globalCooldownLength = new Dictionary<string, double>();
    private Dictionary<string, double> globalCooldowns = new Dictionary<string, double>();
    private Dictionary<GameObject, double> objectsToDestroy = new Dictionary<GameObject, double>();
    private double currentTime;
    public void Awake()
    {
        //populate from json
        globalCooldownLength.Add("dodgeCD", .3);
    }
    void FixedUpdate()
    {
        cooldownChecker();
        destroyChecker();
    }
    public bool requestAbility(String abilityIdx)
    {
        if(globalCooldowns.ContainsKey(abilityIdx))
        {
            return false;
        }
        else
        {
            globalCooldowns.Add(abilityIdx, Time.time + globalCooldownLength[abilityIdx]);
            return true;
        }
    }

    private void cooldownChecker()
    {
        List<String> toRemove = new List<string>();
        foreach( KeyValuePair<string, double> item in globalCooldowns )
        {
            if (item.Value <= Time.time){
                toRemove.Add(item.Key);
            }
        }
        foreach( String item in toRemove ){ globalCooldowns.Remove(item); }
    }

    private void destroyChecker()
    {
        foreach( KeyValuePair<GameObject, double> item in objectsToDestroy )
        {
            Debug.Log(item.Key + " | " + item.Value);
            if (item.Value <= Time.time)
            {
                Destroy(item.Key);
                objectsToDestroy.Remove(item.Key);
            }
        }
    }
}

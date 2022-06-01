using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public bool lightningAbilityPrefabEnabled = false;
    public GameObject lightningAbilityPrefab;
    public bool boardWipeAbilityPrefabEnabled = false;
    public GameObject boardWipeAbilityPrefab;
    public bool healDropAbilityEnabled = false;
    public GameObject healDropAbilityPrefab;
    public bool healPoolAbilityEnabled = false;
    public GameObject healPoolAbilityPrefab;
    

    void Start()
    {
        if(lightningAbilityPrefabEnabled == true)
        {
            Instantiate(lightningAbilityPrefab);
        }

        if(boardWipeAbilityPrefabEnabled == true)
        {
            Instantiate(boardWipeAbilityPrefab);
        }

        if (healDropAbilityEnabled == true)
        {
            Instantiate(healDropAbilityPrefab);
        }

        if (healPoolAbilityEnabled == true)
        {
            Instantiate(healPoolAbilityPrefab);
        }
    }
}
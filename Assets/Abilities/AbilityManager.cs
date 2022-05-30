using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public bool lightningAbilityPrefabEnabled = false;
    public GameObject lightningAbilityPrefab;
    public bool boardWipeAbilityPrefabEnabled = false;
    public GameObject boardWipeAbilityPrefab;
    

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
    }
}
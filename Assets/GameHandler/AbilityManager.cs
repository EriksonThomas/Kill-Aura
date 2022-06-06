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
            AddAbility(lightningAbilityPrefab);
        }

        if(boardWipeAbilityPrefabEnabled == true)
        {
            AddAbility(boardWipeAbilityPrefab);
        }

        if (healDropAbilityEnabled == true)
        {
            AddAbility(healDropAbilityPrefab);
        }

        if (healPoolAbilityEnabled == true)
        {
            AddAbility(healPoolAbilityPrefab);
        }
    }

    private void AddAbility(GameObject prefab)
    {
        GameObject ability = Instantiate(prefab);
        ability.transform.SetParent(transform);
    }
}
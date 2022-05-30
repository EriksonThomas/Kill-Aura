using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject lightningAbilityPrefab;
    public GameObject boardWipeAbilityPrefab;

    void Start()
    {
        Instantiate(lightningAbilityPrefab);
        Instantiate(boardWipeAbilityPrefab);
    }
}
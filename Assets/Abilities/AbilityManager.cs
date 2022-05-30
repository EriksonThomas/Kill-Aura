using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject lightningAbilityPrefab;

    void Start()
    {
        Instantiate(lightningAbilityPrefab);
    }
}
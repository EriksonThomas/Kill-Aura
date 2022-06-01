using UnityEngine;
public class HealingPoolAbility : MonoBehaviour
{
    public float interval = 0.5f;
    public float rangeExponent = 2.5f;
    public float duration = 10f;
    public GameObject healingPoolAbility;
    private Vector3 randomVector;
    private GameObject target;
    private Vector3 dir;

    void Start()
    {
        InvokeRepeating("SpawnHealingPool", 0, interval);
    }

    public void SpawnHealingPool()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * rangeExponent);
        GameObject clone = Instantiate(healingPoolAbility, dir, Quaternion.identity);
        Destroy(clone, duration);
    }
}
using UnityEngine;
public class HealingDropAbility : MonoBehaviour
{
    public float interval = 0.5f;
    public float rangeExponent = 2.5f;
    public float duration = 10f;
    public GameObject healingDropAbility;
    private Vector3 randomVector;
    private GameObject target;
    private Vector3 dir;

    void Start()
    {
        InvokeRepeating("SpawnHealingDrop", 1, interval);
    }

    public void SpawnHealingDrop()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * rangeExponent);
        GameObject clone = Instantiate(healingDropAbility, dir, Quaternion.identity);
        Destroy(clone, duration);
    }
}
using UnityEngine;
public class HealingDropAbility : MonoBehaviour
{
    public float interval = 0.01f;
    public float rangeExponent = 2.5f;
    public float innerBound = 5f;
    public float outerBound = 8f;
    public float duration = 10f;
    public GameObject healingDropAbility;
    private Vector3 randomVector;
    private GameObject target;

    void Start()
    {
        InvokeRepeating("SpawnHealingDrop", 0, interval);
    }

    public void SpawnHealingDrop()
    {
        target = GameHandler.instance.player;
        Vector3 positionOffset = Random.insideUnitCircle.normalized * Random.Range(innerBound, outerBound);
        GameObject clone = Instantiate(healingDropAbility, target.transform.position + positionOffset, Quaternion.identity);
        Destroy(clone, duration);
    }
}
using UnityEngine;
public class HealingDropAbility : MonoBehaviour
{
    public float interval = 0.05f;
    public float rangeExponent = 2.5f;
    public float innerBound = 5f;
    public float outerBound = 8f;
    public float duration = 30f;
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
        var positionOffset = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomVector(innerBound, outerBound);  
        GameObject clone = Instantiate(healingDropAbility, target.transform.position + positionOffset, Quaternion.identity);
        clone.GetComponent<HealingDropEffect>().lifespan = duration;
        Destroy(clone, duration);
    }
}
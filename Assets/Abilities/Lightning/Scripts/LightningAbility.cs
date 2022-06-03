using UnityEngine;
public class LightningAbility : MonoBehaviour
{
    public bool lightningStrike = true;
    public float lightningInterval = 0.5f;
    public float lightningRangeExponent = 2.5f;
    public float lightningDuration = 2.5f;
    public GameObject attackLightningAnimation;
    private Vector3 randomVector;
    private GameObject target;
    private Vector3 dir;

    void Start()
    {
        InvokeRepeating("LightningStrikeAttack", 1, lightningInterval);
    }

    public void LightningStrikeAttack()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * lightningRangeExponent);
        dir.z = 0;
        GameObject clone = Instantiate(attackLightningAnimation, dir, Quaternion.identity);
        Destroy(clone, lightningDuration);
    }
}       
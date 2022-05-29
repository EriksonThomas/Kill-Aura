using UnityEngine;
public class LightningAttack : MonoBehaviour
{
    public bool lightningStrike = true;
    public float lightningInterval = 5.0f;
    public float lightningRangeExponent = 2.5f;
    public float lightningDuration = 2.5f;
    public float lightningDamage = 6f;
    public GameObject attackLightningAnimation;
    private Vector3 randomVector;
    private GameObject target;
    private Vector3 dir;
    public void LightningStrikeAttack()
    {
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * lightningRangeExponent);
        GameObject clone = Instantiate(attackLightningAnimation, dir, Quaternion.identity);
        Destroy(clone, lightningDuration);
    }
}
        
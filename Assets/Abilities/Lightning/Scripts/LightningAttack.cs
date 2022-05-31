using UnityEngine;
public class LightningAttack : MonoBehaviour
{
    public float lightningDamage = 6f;
    private float lightningDamageTimer = 0;
    [SerializeField] private float lightningAttackDelay = 0.4f;
    void Start()
    {
        if (lightningDamageTimer > 0)
        {
            lightningDamageTimer -= Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && lightningDamageTimer <= 0)
        {
            other.GetComponentInParent<EnemyController>().DoDamage(lightningDamage);
            lightningDamageTimer = lightningAttackDelay;
        }
    }
}
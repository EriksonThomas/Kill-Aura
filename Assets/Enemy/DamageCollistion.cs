using UnityEngine;

public class DamageCollistion : MonoBehaviour
{
    private float damageTimer = 0;
    private float lightningDamageTimer = 0;
    [SerializeField] private float timeToAttack = 0.4f;
    [SerializeField] private float lightningAttackDelay = 0.4f;

    void FixedUpdate()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.fixedDeltaTime;
        }
        if (lightningDamageTimer > 0)
        {
            lightningDamageTimer -= Time.fixedDeltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collided with player (layer 8)
        if (other.gameObject.tag == "Player" && damageTimer <= 0)
        {
            other.gameObject.GetComponent<PlayerController2D>().DamageTaken(other.gameObject.GetComponent<BaseAttack>().attackDamage);
            damageTimer = timeToAttack;
        }

        if (other.gameObject.tag == "Lightning" && lightningDamageTimer <= 0)
        {
            gameObject.GetComponentInParent<EnemyController>().DamageTaken(other.GetComponentInParent<LightningAttack>().lightningDamage);
            lightningDamageTimer = lightningAttackDelay;
        }

        if (other.gameObject.tag == "BoardWipe")
        {
            gameObject.GetComponentInParent<EnemyController>().DamageTaken(other.GetComponentInParent<BoardWipeAttack>().BoardWipeDamage);
        }
    }
}

using UnityEngine;

public class DamageCollistion : MonoBehaviour
{
    private float damageTimer = 0;
    [SerializeField] private float timeToAttack = 0.4f;
    void FixedUpdate()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.fixedDeltaTime;
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
    }
}

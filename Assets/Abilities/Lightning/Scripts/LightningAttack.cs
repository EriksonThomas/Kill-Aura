using UnityEngine;
public class LightningAttack : MonoBehaviour
{
    public float lightningDamage = 6f;
    private float lightningDamageTimer = 0;
    [SerializeField] private float lightningAttackDelay = 0.2f;
    void Update()
    {
        
        if (lightningDamageTimer > 0)
        {
            lightningDamageTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && lightningDamageTimer <= 0)
        {
            var randomNumber = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomNumber();
            other.GetComponentInParent<EnemyController>().DoDamage(lightningDamage * randomNumber);
            lightningDamageTimer = lightningAttackDelay;
        }
    }
}
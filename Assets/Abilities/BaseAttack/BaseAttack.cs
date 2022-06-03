using UnityEngine;
public class BaseAttack : MonoBehaviour
{
    public float attackDamage = 5.0f;
    void FixedUpdate()
    {
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DoDamage(attackDamage);
        }
    }
}

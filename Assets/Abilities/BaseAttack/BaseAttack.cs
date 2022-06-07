using UnityEngine;
using System.Collections.Generic;
public class BaseAttack : MonoBehaviour
{   
    public float attackDamage = 5.0f;
    void FixedUpdate()
    {
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TEMPORARY CHECK CAPSULE COLLIDER INSTEAD OF TAG
        if (other.gameObject.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider2D))
        {
            other.GetComponent<EnemyController>().DoDamage(attackDamage);
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DoDamage(attackDamage);
        }
    }
}

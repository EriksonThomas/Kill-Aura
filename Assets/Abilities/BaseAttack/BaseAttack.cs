using UnityEngine;
public class BaseAttack : MonoBehaviour
{   
    private float attackDamage;
    void FixedUpdate()
    {
        attackDamage = GameHandler.instance.player.GetComponent<PlayerStats>().attackDamage;
        Destroy(gameObject, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //TEMPORARY CHECK CAPSULE COLLIDER INSTEAD OF TAG
        if (other.gameObject.tag == "Enemy" && other.GetType() == typeof(CapsuleCollider2D))
        {
            var randomNumber = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomNumber();
            other.GetComponent<EnemyController>().DoDamage(attackDamage * randomNumber);
        }
    }
}

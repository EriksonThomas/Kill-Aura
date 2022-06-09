using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D body;
    void Start()
    {
        //check for the direction of the player
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }
    void FixedUpdate()
    { 
        target = GameHandler.instance.player;
        //move in the direction of the player
        body.velocity = Vector2.zero;
        Vector3 dir = target.transform.position - transform.position;
        //if the enemy is looking left or right flip the sprite
        if(dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f,0,0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f,180,0f);
        }
        //apply movement to the enemy
        transform.position += dir.normalized * gameObject.GetComponent<EnemyStats>().moveSpeed * Time.fixedDeltaTime;
    }
}
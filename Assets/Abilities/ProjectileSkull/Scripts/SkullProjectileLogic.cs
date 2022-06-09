using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SkullProjectileLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileMoveSpeed;
    // public float projectileMoveSpeedStart = 1f;
    private GameObject target;
    private Rigidbody2D body;
    private Vector3 prevMovement;
    void Start()
    {
        //check for the direction of the player
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
        target = GameObject.FindGameObjectWithTag("Enemy");

        GameObject closest = target;
        float closeDistance = Vector3.Distance(gameObject.transform.position, target.transform.position);

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < taggedObjects.Length; i++)
         {
             float thisDistance = Vector3.Distance(gameObject.transform.position, taggedObjects[i].transform.position);
                if( thisDistance <= closeDistance)
                {
                        closeDistance = thisDistance;
                        closest = taggedObjects[i];
                }
         }
         target = closest;
        }else{
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    { 
        if (target != null)
        {
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
            prevMovement = dir.normalized * projectileMoveSpeed * Time.fixedDeltaTime;
            //apply movement to the enemy
        }
        transform.position += prevMovement;  
             
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collided with player (layer 8)
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyController>().DoDamage(5);
        }
    }
}

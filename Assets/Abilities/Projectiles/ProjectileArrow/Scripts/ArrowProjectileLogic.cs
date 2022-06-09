using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArrowProjectileLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileMoveSpeed;
    // public float projectileMoveSpeedStart = 1f;
    private GameObject target;
    private Rigidbody2D body;
    private Vector3 prevMovement;
    public float frequency;  // Speed of sine movement
    public float magnitude;
    private Vector3 axis;
    void Start()
    {
        
        
        //check for the direction of the player
        body = GetComponent<Rigidbody2D>();
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
            prevMovement = dir.normalized * projectileMoveSpeed * Time.fixedDeltaTime;
            //apply movement to the enemy
        }
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward,prevMovement);
        // transform.position+=prevMovement;

        Vector2 perp = Vector2.Perpendicular(new Vector2(prevMovement.x, prevMovement.y));
        axis = Vector3.Normalize(new Vector3(perp.x,perp.y,0));
        transform.position += axis * Mathf.Sin (Time.time * frequency) * magnitude;

        // Vector2 a = new Vector2(prevMovement.x, prevMovement.y);
        // transform.position += prevMovement * Mathf.Sin (Time.time * frequency) * magnitude;
        // transform.position += axis 
             
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

 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using System;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class SkullProjectileLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileMoveSpeed;
    public float adderRange;
    public GameObject explosion;
    // public float projectileMoveSpeedStart = 1f;
    private GameObject target;
    private Rigidbody2D body;
    private Vector3 prevMovement;
    List<GameObject> closestTargets = new List<GameObject>();
    void Start()
    {
        //check for the direction of the player
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < taggedObjects.Length; i++)
            {
                float thisDistance = Vector3.Distance(GameHandler.instance.player.transform.position, taggedObjects[i].transform.position);
                    if( thisDistance <= adderRange)
                    {
                        closestTargets.Add(taggedObjects[i]);
                    }
            }
            if(closestTargets.Count > 0)
            {
                Vector3 averagePos = Vector3.zero;
                foreach( GameObject item in closestTargets )
                {
                    averagePos += item.transform.position;
                }
                averagePos = averagePos /  closestTargets.Count;

                target = GameObject.FindGameObjectWithTag("Enemy");
                for(int i = 0; i < taggedObjects.Length; i++)
                {
                float thisDistance = Vector3.Distance(averagePos, taggedObjects[i].transform.position);
                    if( thisDistance <= Vector3.Distance(averagePos, target.transform.position))
                    {
                        target = taggedObjects[i];
                    }
                }

            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
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
        if (other.gameObject == target)
        {
            Instantiate(explosion, other.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

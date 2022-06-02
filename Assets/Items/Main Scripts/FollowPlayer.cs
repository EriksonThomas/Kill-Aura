using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    public float minimumDistance;
    private Vector3 randomPosition;
    private float vectorTimer = 1;
    private Vector3 randomDir;
    private Vector3 lastTargetPos;
    void FixedUpdate()
    {
        //Set no rotation of on collision
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //calculate distance between the target and the object following
        var distanceDifference = Vector3.Distance(target.transform.position, transform.position);
        
        if(Vector2.Distance(target.transform.position, lastTargetPos) < .1f)
        {
            //Check to see if the object is in minimum distance of the target
            if(distanceDifference >= minimumDistance)
            {
                //follow the plater if outside the minimium distance
                Vector3 dir = target.transform.position - transform.position;
                transform.position += dir.normalized * moveSpeed * Time.fixedDeltaTime;
            }
            else
            {
                if (vectorTimer > 0)
                {
                    vectorTimer -= Time.fixedDeltaTime;
                }
                else
                {
                    //Get a random vector and float while inside the correct distance of the target
                    moveSpeed = 0.3f;
                    randomDir = RandomVector(randomPosition, new Vector3(10f, 10f, 0), new Vector3(20f, 20f, 0));
                    vectorTimer = 1.0f;
                }
                transform.position += randomDir.normalized * moveSpeed * Time.fixedDeltaTime;
            }       
        }
        lastTargetPos = target.transform.position;
    }
    public Vector3 RandomVector(Vector3 myVector, Vector3 min, Vector3 max)
    {
        //generate random vector within set bounds
        myVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
        return myVector;
    }
}

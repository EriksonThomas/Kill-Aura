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
    void Update()
    {
        //Set no rotation of on collision
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //calculate distance between the target and the object following
        var distanceDifference = Vector3.Distance(target.transform.position, transform.position);
        if(distanceDifference + .2 >= minimumDistance)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (vectorTimer > 0)
            {
                vectorTimer -= Time.deltaTime;
                moveSpeed = 0.3f;
                if(target.transform.position == lastTargetPos)
                {
                    transform.position += randomDir.normalized * moveSpeed * Time.deltaTime;
                }
                //transform.position += randomDir.normalized * moveSpeed * Time.deltaTime;
            }
            else if(vectorTimer <= 0)     
            {
                lastTargetPos = target.transform.position;
                randomDir = RandomVector(randomPosition, new Vector3(5f, 5f, 0), new Vector3(8f, 8f, 0));
                vectorTimer = 1;
            }
        }
        
        
        
    }
    public Vector3 RandomVector(Vector3 myVector, Vector3 min, Vector3 max)
    {
        //generate random vector within set bounds
        myVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
        return myVector;
    }
}

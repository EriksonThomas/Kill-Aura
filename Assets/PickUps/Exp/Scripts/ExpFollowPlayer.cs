using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFollowPlayer : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    
    private float vectorTimer = 1;
    private Vector3 randomDir;
    private Vector3 lastTargetPos;
    void Start()
    {
        target = GameHandler.instance.player;
    }
    void Update()
    {
        Vector3 adjusted = target.transform.position + new Vector3(0,-.14f);
        //calculate distance between the target and the object following
        var distanceDifference = Vector3.Distance(adjusted + new Vector3(0,0), transform.position);
        if(distanceDifference >= 0)
        {
            Vector3 dir = adjusted - transform.position;
            //speed exp balls up as they approach the target
            transform.position += dir.normalized * ((1 / distanceDifference) * .5f) * Time.deltaTime;
        }
        else
        {
            vectorTimer -= Time.deltaTime;
            moveSpeed = 0.3f;
            if(adjusted == lastTargetPos)
            {
                transform.position += randomDir.normalized * moveSpeed * Time.deltaTime;
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

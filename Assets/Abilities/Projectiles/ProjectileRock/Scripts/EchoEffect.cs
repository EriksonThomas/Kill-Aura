using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timeBtwSpawns <=0)
        {
            GameObject temp = Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(temp, 4f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.fixedDeltaTime;
        }
    }
}

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
            float offsetX =(float)(Random.Range(0,10)/10);
            float offsetY = (float)(Random.Range(0,10)/10);
            Debug.Log(offsetX.ToString() +"|" + offsetY.ToString());
            Vector3 offset = new Vector3(offsetX,offsetY,0);
            GameObject temp = Instantiate(echo, transform.position + offset, Quaternion.identity);
            Destroy(temp, 4f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.fixedDeltaTime;
        }
    }
}

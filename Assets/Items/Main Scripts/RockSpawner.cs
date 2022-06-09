using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject deleteme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.instance.globalTimer.GetComponent<GlobalTimer>().requestAbility("rockspawn"))
        {
            Instantiate(deleteme, gameObject.GetComponent<Transform>().position,Quaternion.identity);
            Debug.Log("spawnign");
        }
    }
}

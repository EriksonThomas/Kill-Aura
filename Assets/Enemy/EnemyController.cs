using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    private float dazedTime;
    public float startDazedTime = 2;

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(dazedTime <= 0)
        {
            gameObject.GetComponent<EnemyMovement>().moveSpeed = gameObject.GetComponent<EnemyMovement>().moveSpeedStart;
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>().moveSpeed = 0.0f;
            dazedTime -= Time.fixedDeltaTime;
        }
    }
    public void DamageTaken(float damage)
    {
        dazedTime = startDazedTime;
        currentHealth -= damage;
        //Debug.Log(currentHealth);
    } 
}

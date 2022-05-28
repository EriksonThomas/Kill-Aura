using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageTaken(float damage)
    {
        currentHealth -= damage;
        //Debug.Log(currentHealth);
    } 
}

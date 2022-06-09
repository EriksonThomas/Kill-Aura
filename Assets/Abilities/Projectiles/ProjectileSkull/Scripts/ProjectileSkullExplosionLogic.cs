using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkullExplosionLogic : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collided with player (layer 8)
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject, 0.1f);
            other.gameObject.GetComponent<EnemyController>().DoDamage(1);
        }
    }
}

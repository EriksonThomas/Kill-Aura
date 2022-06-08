using UnityEngine;
public class DamageNumbersDestroy : MonoBehaviour
{
    private float destroyTimer = 0.2f;
    void Update()
    {
        if (destroyTimer > 0)
        {
            destroyTimer -= Time.deltaTime;
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        }
        else
        {
         
           Destroy(gameObject, .2f);
        }
    }
}
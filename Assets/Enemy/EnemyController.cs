using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    private float dazedTime;
    public float startDazedTime = 2;
    private float randomCount;
    public GameObject gemPrefab;

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
        for (float i = 0; i <= Random.Range(0, 5.0f); i++)
        {
            gameObject.transform.position = gameObject.transform.position + (Random.insideUnitSphere * .3f);
            GameObject gem = Instantiate(gemPrefab, gameObject.transform.position, Quaternion.identity);
        }
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
    } 
}

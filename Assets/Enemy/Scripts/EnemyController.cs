using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    private float dazedTime;
    public float startDazedTime = 2;
    private float randomCount;
    public GameObject[] gemPrefab;
    public GameObject[] expPrefab;
    private int randomNumber;
    public float attackDamage;
    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            for (float i = 0; i <= Random.Range(0, 5.0f); i++)
            {
                // Take a random number in Gem Prefab array and cast it to the spawn it in on death
                randomNumber = Random.Range(0, gemPrefab.Length);
                gameObject.transform.position = gameObject.transform.position + (Random.insideUnitSphere * .3f);
                GameObject gem = Instantiate(gemPrefab[randomNumber], gameObject.transform.position, Quaternion.identity);
            }

            for (float i = 0; i <= Random.Range(0, 3.0f); i++)
            {
                // Take a random number in EXP Prefab array and cast it to the spawn it in on death
                randomNumber = Random.Range(0, 2);
                Debug.Log(randomNumber);
                gameObject.transform.position = gameObject.transform.position + (Random.insideUnitSphere * .3f);
                GameObject exp = Instantiate(expPrefab[0], gameObject.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        // Daze on damaged
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
    public void DoDamage(float damage)
    {
        dazedTime = startDazedTime;
        currentHealth -= damage;       
    }
}

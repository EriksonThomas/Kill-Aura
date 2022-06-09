using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameObject target;
    private Vector3 dir;
    private int randomNumber;
    public float currentDamageDebug;
    public float currentHealthDebug;
    private int randomEnemy;
    private float innerBound = 6;
    private float outerBound = 8;
    void Start()
    {
        //set spawning interval for enemies and kill the mob spawner after a set amount of time
        InvokeRepeating("SpawnEnemy", 2f, .4f);
        Destroy(gameObject, WaveManager.instance.GetComponent<WaveManager>().GenerateWaveLength());
    }
    void Update()
    {
        gameObject.transform.position = GameHandler.instance.player.GetComponent<Transform>().position;
    }
    void SpawnEnemy()
    {
        //generate a randomized enemy prefab from the array
        randomNumber = Random.Range(0, 100);
        if(randomNumber < 5)
        {
            randomEnemy = 0;
        }
        else if(randomNumber > 5 && randomNumber < 45)
        {   
            randomEnemy = 0;
        }
        else if(randomNumber > 45 && randomNumber < 94)
        {
            randomEnemy = 1;
        }
        else
        {
            randomEnemy = 2;
        }
      

        //get the current wave number from WaveManager
        var waveNumber = WaveManager.instance.GetComponent<WaveManager>().waveNumber;
        //Find the location of the player and get a random point in a large radius around the player to instansiate the enemy
        //spawn the randomized enemy
        //get the enemycontroller componenet for the current enemy
        //scale current damage annd hp of the spawned enemy to scale with waveNumber
        var positionOffset = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomVector(innerBound, outerBound);
        var adjusted = gameObject.transform.position + positionOffset;

        GameObject currentEnemy = Instantiate(enemyPrefab[randomEnemy], adjusted, Quaternion.identity);

        currentEnemy.GetComponent<EnemyStats>().attackDamage = currentEnemy.GetComponent<EnemyStats>().attackDamage + (waveNumber / 6);
        currentEnemy.GetComponent<EnemyStats>().maxHealth = currentEnemy.GetComponent<EnemyStats>().maxHealth + (waveNumber / 2);
        currentEnemy.GetComponent<EnemyStats>().currentHealth = currentEnemy.GetComponent<EnemyStats>().currentHealth + (waveNumber / 2);
    }
    void OnDestroy()
    {
        //set wave in progress to false and reset the timer when the wave is over
        WaveManager.instance.waveInProgress = false;
        WaveManager.instance.waveTimer = 5.0f;
    }
}

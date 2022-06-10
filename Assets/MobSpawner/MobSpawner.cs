using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameObject target;
    private Vector3 dir;
    private int randomNumber;
    private int randomEnemy;
    private float innerBound = 6;
    private float outerBound = 7;
    void Start()
    {
        //set spawning interval for enemies and kill the mob spawner after a set amount of time
        InvokeRepeating("SpawnEnemy", 2f, .3f);
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
        if(randomNumber <= 12)
        {
            randomEnemy = 4;
        }
        else if(randomNumber > 12 && randomNumber < 45)
        {   
            randomEnemy = 0;
        }
        else if(randomNumber >= 45 && randomNumber < 94)
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
        Debug.Log(enemyPrefab[randomEnemy]);
        currentEnemy.GetComponent<EnemyStats>().ScaleEnemy(waveNumber);

    }
    void OnDestroy()
    {
        //set wave in progress to false and reset the timer when the wave is over
        WaveManager.instance.waveInProgress = false;
        WaveManager.instance.waveTimer = 5.0f;
    }
}

using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameObject target;
    private Vector3 dir;
    private int randomNumber;
    void Start()
    {
        //set spawning interval for enemies and kill the mob spawner after a set amount of time
        InvokeRepeating("SpawnEnemy", 2f, .4f);
        Destroy(gameObject, WaveManager.instance.GetComponent<WaveManager>().GenerateWaveLength());
    }
    void SpawnEnemy()
    {
        //get the current wave number from WaveManager
        var waveNumber = WaveManager.instance.GetComponent<WaveManager>().waveNumber;

        enemyPrefab[0].GetComponent<EnemyController>().attackDamage = enemyPrefab[1].GetComponent<EnemyController>().attackDamage + (waveNumber / 10);
        enemyPrefab[1].GetComponent<EnemyController>().attackDamage = enemyPrefab[1].GetComponent<EnemyController>().attackDamage + (waveNumber / 10);

        enemyPrefab[0].GetComponent<EnemyController>().currentHealth = enemyPrefab[1].GetComponent<EnemyController>().currentHealth + (waveNumber / 2);
        enemyPrefab[1].GetComponent<EnemyController>().currentHealth = enemyPrefab[1].GetComponent<EnemyController>().currentHealth + (waveNumber / 2);

        //Find the location of the player and get a random point in a large radius around the player to instansiate the enemy
        target = GameHandler.instance.player;
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * 9.0f);
        randomNumber = Random.Range(0, enemyPrefab.Length);
        dir.z = 0;
        //spawn a randomized enemy prefab from the array
        Instantiate(enemyPrefab[randomNumber], dir, Quaternion.identity);
    }
    void OnDestroy()
    {
        //set wave in progress to false and reset the timer when the wave is over
        WaveManager.instance.waveInProgress = false;
        WaveManager.instance.waveTimer = 5.0f;
    }
}

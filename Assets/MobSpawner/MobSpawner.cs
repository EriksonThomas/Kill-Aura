using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameObject target;
    private Vector3 dir;
    private int randomNumber;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
    }
    void SpawnEnemy()     
    {
        //Find the location of the player and get a random point in a large radius around the player to instansiate the enemy
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * 5.0f);
        randomNumber = Random.Range(0, enemyPrefab.Length);
        dir.z = 0;
        Instantiate(enemyPrefab[randomNumber], dir, Quaternion.identity);
    }
}

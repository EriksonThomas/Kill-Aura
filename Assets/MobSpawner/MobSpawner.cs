using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Vector3 randomVector;
    private GameObject target;
    private Vector3 dir;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void SpawnEnemy()     
    {
        target = GameObject.Find("Player");
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * 5.0f);
        Instantiate(enemyPrefab, dir, Quaternion.identity);
    }
}

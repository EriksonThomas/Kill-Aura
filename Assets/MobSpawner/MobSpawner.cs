using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

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
        Instantiate(enemyPrefab, Vector2.zero, Quaternion.identity);
    }
}

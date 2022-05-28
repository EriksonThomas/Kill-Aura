using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject enemySpawnerPrefab; 
    private GameObject enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
        Destroy(enemySpawner, 20f);
    }
}

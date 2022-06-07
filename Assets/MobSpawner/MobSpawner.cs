﻿using UnityEngine;
public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private GameObject target;
    private Vector3 dir;
    private int randomNumber;
    public float currentDamageDebug;
    public float currentHealthDebug;
    private int randomEnemy;
    void Start()
    {
        //set spawning interval for enemies and kill the mob spawner after a set amount of time
        InvokeRepeating("SpawnEnemy", 2f, .4f);
        Destroy(gameObject, WaveManager.instance.GetComponent<WaveManager>().GenerateWaveLength());
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
        target = GameHandler.instance.player;
        dir = target.transform.position;
        dir = dir + (Random.insideUnitSphere * 9.0f);
        dir.z = 0;

        //spawn the randomized enemy
        //get the enemycontroller componenet for the current enemy
        //scale current damage annd hp of the spawned enemy to scale with waveNumber
        GameObject currentEnemy = Instantiate(enemyPrefab[randomEnemy], dir, Quaternion.identity);
        
        //var enemyController = currentEnemy.GetComponent<EnemyController>();

        var attackDamage = currentEnemy.GetComponent<EnemyController>().attackDamage;

        currentEnemy.GetComponent<EnemyController>().attackDamage = currentEnemy.GetComponent<EnemyController>().attackDamage + (waveNumber / 6);
        currentDamageDebug = currentEnemy.GetComponent<EnemyController>().attackDamage / attackDamage;
        //Debug.Log("Enemy DMG scaled by: " + currentEnemy.GetComponent<EnemyController>().attackDamage / attackDamage + "x");
        
        currentEnemy.GetComponent<EnemyController>().maxHealth = currentEnemy.GetComponent<EnemyController>().maxHealth + (waveNumber / 2);
        currentEnemy.GetComponent<EnemyController>().currentHealth = currentEnemy.GetComponent<EnemyController>().currentHealth + (waveNumber / 2);
        //Debug.Log("Enemy HP: " + currentEnemy.GetComponent<EnemyController>().currentHealth);
    }
    void OnDestroy()
    {
        //set wave in progress to false and reset the timer when the wave is over
        WaveManager.instance.waveInProgress = false;
        WaveManager.instance.waveTimer = 5.0f;
    }
}

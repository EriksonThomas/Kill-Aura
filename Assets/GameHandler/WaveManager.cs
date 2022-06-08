using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public GameObject enemySpawnerPrefab;
    public bool mobSpawnerEnabled;
    public bool waveInProgress;
    public float waveNumber;
    public float waveNumberCleared;
    public float currentWaveLength;
    public float waveTimer;
    public float waveTextTimer;
    private bool waveProgressComplete;
    private GameObject waveNumberTextObject;
    public int normalEnemyMeterMax;
    public int eliteEnemyMeterMax;
    public int bossEnemyMeterMax;
    [System.NonSerialized] public bool startNextWave;

    void Start()
    {
        //instance the script and find WaveNumber text
        instance = this;
        waveNumberTextObject = GameObject.Find("WaveNumber");
        //waveNumberTextObject.SetActive(true);
    }
    void Update()
    {
        //check to see if mob spawner is enabled on the WaveManager GameObject
        if(mobSpawnerEnabled == true)
        {
            if(waveTimer <= 0)
            {
                if(waveTextTimer > 0)
                {
                    waveNumberTextObject.SetActive(true);
                    waveTextTimer -= Time.deltaTime;
                }
                else
                {
                    waveNumberTextObject.SetActive(false);
                    Debug.Log("spawning wave");
                    waveNumberTextObject.SetActive(false);
                    //If the timer is complete hide the text and spawn a new wave
                    waveNumber += 1;
                    GameObject spawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
                    waveTimer = currentWaveLength;
                }
            }
            else if(waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
            }
        }

        var player = GameHandler.instance.player.GetComponent<PlayerStats>();
        if(player.normalEnemyMeter >= normalEnemyMeterMax && player.eliteEnemyMeter >= eliteEnemyMeterMax && player.bossEnemyMeter >= bossEnemyMeterMax)
        {
            waveProgressComplete = true;
            waveNumberCleared += 1;
        }

        if(waveProgressComplete == true)
        {
            Debug.Log("Wave cleared " + waveNumberCleared);
            //waveNumberTextObject.SetActive(true);
            waveProgressComplete = false;
            player.normalEnemyMeter = 0;
            player.eliteEnemyMeter = 0;
            player.bossEnemyMeter = 0;
            //TODO CODE FOR PLAYER LEVEL Up
        }
    }
    public float GenerateWaveLength()
    {
        //increse the wave time based on what round it is
        waveTimer = currentWaveLength;
        waveTextTimer = 2f;
        currentWaveLength = currentWaveLength * 1.1f;
        return currentWaveLength;
    }
}
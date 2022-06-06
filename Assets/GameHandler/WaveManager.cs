using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemySpawnerPrefab;
    public bool mobSpawnerEnabled;
    public bool waveInProgress = false;
    public float waveNumber = 0;
    public float currentWaveTime;
    public static WaveManager instance;
    public float waveTimer;
    private GameObject waveNumberTextObject;
    void Start()
    {
        //instance the script and find WaveNumber text
        instance = this;
        waveNumberTextObject = GameObject.Find("WaveNumber");
        waveNumberTextObject.SetActive(true);
    }
    void Update()
    {
        //check to see if mob spawner is enabled on the WaveManager GameObject
        if(mobSpawnerEnabled == true)
        {
            //check to see if there is a wave in progress
            if(waveInProgress == false)
            {
                //set a timer between rounds to display round number
                if (waveTimer > 0)
                { 
                    waveNumberTextObject.SetActive(true);
                    waveTimer -= Time.deltaTime;
                }
                //If the timer is complete hide the text and spawn a new wave
                else
                {
                    waveNumberTextObject.SetActive(false);
                    waveInProgress = true;
                    waveNumber += 1;
                    GameObject spawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
                }
            }
        }
    }
    public float GenerateWaveLength()
    {
        //increse the wave time based on what round it is
        currentWaveTime = currentWaveTime * 1.1f;
        return currentWaveTime;
    }
}
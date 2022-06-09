using UnityEngine;
using UnityEngine.UI;

public class EliteEnemyProgress : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {

        var playerProgress = GameHandler.instance.player.GetComponent<PlayerStats>().eliteEnemyMeter;
        var playerProgressNeeded = WaveManager.instance.GetComponent<WaveManager>().eliteEnemyMeterMax;
        Debug.Log("fuck ya" + (float) playerProgress / (float) playerProgressNeeded);
        float fillValue = (float) playerProgress / (float) playerProgressNeeded;
        slider.value = fillValue;
    }
}

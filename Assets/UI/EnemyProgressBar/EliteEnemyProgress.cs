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
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value  > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        var playerProgress = GameHandler.instance.player.GetComponent<PlayerStats>().eliteEnemyMeter;
        var playerProgressNeeded = WaveManager.instance.GetComponent<WaveManager>().eliteEnemyMeterMax;  
        Debug.Log("fuck you" + (float) playerProgress / (float) playerProgressNeeded);
        float fillValue = (float) playerProgress / (float) playerProgressNeeded;
        //slider.value = (float) playerProgress / (float) playerProgressNeeded * 100.0;
        slider.value = fillValue;
        Debug.Log(slider.value);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Text sliderText;
    public Image fillImage;
    private Slider slider;
    private PlayerStats playerStats;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        playerStats = GameHandler.instance.player.GetComponent<PlayerStats>();

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value  > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        //float fillValue = playerStats.currentStamina / playerStats.maxStamina;
        var playerProgress = GameHandler.instance.player.GetComponent<PlayerStats>().eliteEnemyMeter;
        var playerProgressNeeded = WaveManager.instance.GetComponent<WaveManager>().eliteEnemyMeterMax;
        float fillValue = (float) playerProgress / (float) playerProgressNeeded;
        
        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }



        slider.value = fillValue;
        //slider.value = fillValue;
        //sliderText.text = playerStats.currentStamina.ToString("00") + "/" + playerStats.maxStamina;
    }
}

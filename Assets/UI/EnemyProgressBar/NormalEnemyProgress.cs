using UnityEngine;
using UnityEngine.UI;

public class NormalEnemyProgress : MonoBehaviour
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

        var playerProgress = GameHandler.instance.player.GetComponent<PlayerStats>().normalEnemyMeter;
        var playerProgressNeeded = WaveManager.instance.GetComponent<WaveManager>().normalEnemyMeterMax;

        float fillValue = (float) playerProgress / (float) playerProgressNeeded;
        Debug.Log(fillValue);
        slider.value = fillValue;
    }
}

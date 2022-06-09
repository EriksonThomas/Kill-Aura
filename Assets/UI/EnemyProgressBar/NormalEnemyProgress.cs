using UnityEngine;
using UnityEngine.UI;

public class NormalEnemyProgress : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
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
        Debug.Log("fuck ya" + (float) playerProgress / (float) playerProgressNeeded);
        float fillValue = (float) playerProgress / (float) playerProgressNeeded;
        slider.value = fillValue;
    }
}

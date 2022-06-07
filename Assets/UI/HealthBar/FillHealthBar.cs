using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    private PlayerController2D playerScript;
    public Text sliderText;
    public Image fillImage;
    private Slider slider;
    private PlayerStats playerStats;
    
    void Awake()
    {
        //playerStats = gameObject.GetComponent<PlayerStats>();
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

        float fillValue = playerStats.currentHealth / playerStats.maxHealth;

        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }

        slider.value = fillValue;
        sliderText.text = playerStats.currentHealth.ToString("00") + "/" + playerStats.maxHealth;
    }
}

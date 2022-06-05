using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
private PlayerController2D playerScript;
public Text sliderText;
public Image fillImage;
private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        playerScript = GameHandler.instance.player.GetComponent<PlayerController2D>();

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value  > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = playerScript.currentHealth / playerScript.maxHealth;

        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }

        slider.value = fillValue;
        sliderText.text = playerScript.currentHealth.ToString("00") + "/" + playerScript.maxHealth;
    }
}

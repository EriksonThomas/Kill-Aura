﻿using UnityEngine;
using UnityEngine.UI;

public class FillStaminaBar : MonoBehaviour
{
private PlayerController2D playerScript;
public Text sliderText;
public Image fillImage;
private Slider slider;

    void Start()
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

        float fillValue = playerScript.currentStamina / playerScript.maxStamina;

        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }

        slider.value = fillValue;
        sliderText.text = playerScript.currentStamina.ToString("00") + "/" + playerScript.maxStamina;
    }
}

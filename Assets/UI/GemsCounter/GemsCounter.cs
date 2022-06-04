﻿using UnityEngine;
using UnityEngine.UI;
public class GemsCounter : MonoBehaviour
{
public Text sliderText;
    void Update()
    {
        //change text in UI to reflect gem count of player
        sliderText.text = GameObject.Find("Player").GetComponent<PlayerController2D>().startingGems.ToString("00");
    }
}
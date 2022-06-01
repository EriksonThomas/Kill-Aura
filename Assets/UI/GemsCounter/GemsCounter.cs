using UnityEngine;
using UnityEngine.UI;
public class GemsCounter : MonoBehaviour
{
public PlayerController2D playerScript;
public Text sliderText;
    void Update()
    {
        //change text in UI to reflect gem count of player
        sliderText.text = playerScript.startingGems.ToString("00");
    }
}
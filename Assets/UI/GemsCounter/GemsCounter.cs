using UnityEngine;
using UnityEngine.UI;

public class GemsCounter : MonoBehaviour
{
public PlayerController2D playerScript;
public Text sliderText;
    void Update()
    {
        sliderText.text = playerScript.startingGems.ToString("00");
    }
}

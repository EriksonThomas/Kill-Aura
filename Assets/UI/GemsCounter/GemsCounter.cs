using UnityEngine;
using UnityEngine.UI;
public class GemsCounter : MonoBehaviour
{
public Text sliderText;
    void Update()
    {
        //change text in UI to reflect gem count of player
        sliderText.text = GameHandler.instance.player.GetComponent<PlayerController2D>().startingGems.ToString("00");
    }
}
using UnityEngine;
using UnityEngine.UI;
public class WaveNumberClearedUI : MonoBehaviour
{
private string Number;
public Text waveNumberText;
    void Update()
    {
        //change text in UI to reflect gem count of player\
        Number = WaveManager.instance.GetComponent<WaveManager>().waveNumberCleared.ToString();
        waveNumberText.text = ("Cleared Wave: " + Number);
    }
}
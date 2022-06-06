using UnityEngine;
using UnityEngine.UI;
public class WaveNumberUI : MonoBehaviour
{
private string Number;
public Text waveNumberText;
    void Update()
    {
        //change text in UI to reflect gem count of player\
        Number = WaveManager.instance.GetComponent<WaveManager>().waveNumber.ToString();
        waveNumberText.text = ("Wave Number: " + Number);
    }
}
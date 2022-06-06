using UnityEngine;
using UnityEngine.UI;
public class DebugMenu : MonoBehaviour
{
    public Text debugMenu;
    void Start()
    {   
    }
    void Update()
    {
        var debug = GameObject.Find("MobSpawnerPrefab(Clone)");
        if(debug != null)
        {
            debugMenu.text = ("Enemy DMG scaled by: " + debug.GetComponent<MobSpawner>().currentDamageDebug + "x");
        }
        //change text in UI to reflect gem count of player
        //debugMenu.text = ("Current Enemy DMG: " + mobSpawner.ToString());
    }
}
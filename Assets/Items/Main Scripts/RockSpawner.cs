using UnityEngine;
public class RockSpawner : MonoBehaviour
{
    public GameObject deleteme;
    void Update()
    {
        if (GameHandler.instance.globalTimer.GetComponent<GlobalTimer>().requestAbility("rockspawn"))
        {
            Instantiate(deleteme, gameObject.GetComponent<Transform>().position,Quaternion.identity);
        }
    }
}
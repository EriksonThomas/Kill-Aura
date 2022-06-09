using UnityEngine;
public class SkullSpawner : MonoBehaviour
{
    public GameObject deleteme;
    void Start()
    {
        
    }
    void Update()
    {
        if (GameHandler.instance.globalTimer.GetComponent<GlobalTimer>().requestAbility("skullspawn"))
        {
            Instantiate(deleteme, gameObject.GetComponent<Transform>().position,Quaternion.identity);
        }
    }
}
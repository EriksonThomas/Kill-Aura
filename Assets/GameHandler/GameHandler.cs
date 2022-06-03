using UnityEngine;
public class GameHandler : MonoBehaviour
{
    public GameObject enemySpawnerPrefab; 
    public bool mobSpawnerEnabled;
    void Start()
    {
        if(mobSpawnerEnabled == true)
        {
        GameObject spawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
        Destroy(spawner, 40f);
        }
    }
}

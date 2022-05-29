using UnityEngine;
public class GameHandler : MonoBehaviour
{
    public GameObject enemySpawnerPrefab; 
    void Start()
    {
        GameObject spawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
        Destroy(spawner, 40f);
    }
}

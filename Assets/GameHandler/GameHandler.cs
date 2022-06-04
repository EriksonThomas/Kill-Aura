using UnityEngine;
using UnityEditor;
public class GameHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemySpawnerPrefab;
    public bool mobSpawnerEnabled;
    void Awake()
    {
        GameObject Player = PrefabUtility.InstantiatePrefab(playerPrefab.gameObject as GameObject) as GameObject;
    }
    void Start()
    {
        if(mobSpawnerEnabled == true)
        {
        GameObject spawner = Instantiate(enemySpawnerPrefab, Vector3.zero, Quaternion.identity);
        Destroy(spawner, 40f);
        }
    }
}

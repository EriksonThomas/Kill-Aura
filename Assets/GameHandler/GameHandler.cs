using UnityEngine;
using UnityEditor;
public class GameHandler : MonoBehaviour
{
    // instance of GameHandler singleton
    private static GameHandler _instance;
    public static GameHandler instance { get { return _instance; } }
    public GameObject playerPrefab;
    private GameObject _player;
    public GameObject player { get { return _player; } }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    void Start()
    {
        _player = Instantiate(playerPrefab);
    }


}

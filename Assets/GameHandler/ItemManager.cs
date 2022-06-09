using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool diceItemEnabled = false;
    public GameObject diceItemyPrefab;
    public bool rocksItemEnabled = false;
    public GameObject rocksItemyPrefab;
    public bool puzzleItemEnabled = false;
    public GameObject puzzleItemyPrefab;
    

    void Start()
    {
        if(diceItemEnabled == true)
        {
            Instantiate(diceItemyPrefab);
        }

        if(puzzleItemEnabled == true)
        {
            Instantiate(puzzleItemyPrefab);
        }
        
        if(rocksItemEnabled == true)
        {
            Instantiate(rocksItemyPrefab);
        }
    }
}
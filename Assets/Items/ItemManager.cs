using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool diceItemEnabled = false;
    public GameObject diceItemyPrefab;
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
    }
}
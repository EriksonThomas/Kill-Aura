using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffectRockChooser : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] allSprites;
    void Start()
    {
        int rand = Random.Range(0, allSprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = allSprites[rand];
    }
}

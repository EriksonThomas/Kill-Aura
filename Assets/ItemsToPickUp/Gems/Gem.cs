using UnityEngine;
public class Gem : MonoBehaviour
{
    public Sprite[] gemSprite;
    int randomNumber;
    void Start()
    {
        //Take a random number in Sprite array and cast it to the sprite renderer
        randomNumber = Random.Range(0, gemSprite.Length);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = gemSprite[randomNumber];
        Destroy(gameObject, 15f);
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
}

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
        if(gameObject.GetComponentInChildren<SpriteRenderer>().sprite = gemSprite[5])
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Collected();
            other.gameObject.GetComponentInParent<PlayerController2D>().GemCollected(1);
        }
    }
}


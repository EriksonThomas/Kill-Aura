using UnityEngine;
public class Gem5 : MonoBehaviour
{
    public float gemValue = 5.0f;
    void Start()
    {
        Destroy(gameObject, 15f);
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Collected();
            other.gameObject.GetComponentInParent<PlayerController2D>().GemCollected(gemValue);
        }
    }
}
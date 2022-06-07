using UnityEngine;
public class SnailTrailBehaviour : MonoBehaviour
{
    public float snailTrailDamage;
    void Start()
    {
        Destroy(gameObject, 20f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Collided with player (layer 8)
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController2D>().DoDamage(snailTrailDamage);
            //other.gameObject.GetComponent<PlayerMovement>().moveSpeed = other.gameObject.GetComponent<PlayerMovement>().moveSpeed * 0.2f;
        }
    }
}

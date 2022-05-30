using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Gem")
        {
            Debug.Log("gem col");
            other.gameObject.GetComponent<Gem>().Collected();
        }
    }
}

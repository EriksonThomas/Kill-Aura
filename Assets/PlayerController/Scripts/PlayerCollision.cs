using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //When layer collides with gem
        if (other.gameObject.tag == "Gem")
        {
            //Call method Collected in "Gem" Script to destroy gem on pickup
            other.gameObject.GetComponentInParent<Gem>().Collected();
        }
    }
}

using UnityEngine;
public class HealingDropEffect : MonoBehaviour
{
    public float healValue = 6f;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered == false && other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<PlayerController2D>().DoHeal(healValue);
            hasTriggered = true;
            Destroy(gameObject);
        }
    }
}
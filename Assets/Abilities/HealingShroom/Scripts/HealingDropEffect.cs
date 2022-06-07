using UnityEngine;
public class HealingDropEffect : MonoBehaviour
{
    public float healValue = 6f;
    public GameObject burstPrefab;  
    public AudioSource audioSource;
    public AudioClip Mushroom;
    public float volume = 5f;
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered == false && other.gameObject.tag == "Player")
        {
            // enable pop animatino and destroy when done
            GetComponent<Animator>().enabled = true;
            AudioSource.PlayClipAtPoint(Mushroom, transform.position);
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

            // burst particles
            // GameObject part = Instantiate(burstPrefab);
            // part.transform.position = transform.position;
            // Destroy(part, 2);

            // heal player
            other.GetComponentInParent<PlayerController2D>().DoHeal(healValue);
            hasTriggered = true;
        }
    }
}
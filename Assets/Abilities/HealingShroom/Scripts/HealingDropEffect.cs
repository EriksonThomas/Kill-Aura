using UnityEngine;
public class HealingDropEffect : MonoBehaviour
{
    public float healValue = 6f;
    public GameObject burstPrefab;  
    public AudioSource audioSource;
    public AudioClip Mushroom;
    public GameObject MushroomSprite; // child object with mushy
    public SpriteRenderer MushySprite;
    public float volume = 5f;
    public float lifespan; // set lifespan when this is instantiated so it knows when to fade
    private bool hasTriggered = false;
    private bool isFading = false;
    void Start()
    {
        MushySprite = MushroomSprite.GetComponent<SpriteRenderer>();
        Invoke("FadeAway", lifespan - 3f);
    }
    void Update()
    {
        if (isFading)
        {
            var alpha = MushySprite.color.a;
            alpha -= 0.3f * Time.deltaTime;
            if (alpha >= 0)
            {
                MushySprite.color = new Color(1, 1, 1, alpha);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered == false && other.gameObject.tag == "Player")
        {
            // enable pop animatino and destroy when done
            MushroomSprite.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Animator>().enabled = true;
            AudioSource.PlayClipAtPoint(Mushroom, transform.position);
            Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

            // burst particles
            // GameObject part = Instantiate(burstPrefab);
            // part.transform.position = transform.position;
            // Destroy(part, 2);

            // heal player
            var randomNumber = GameHandler.instance.GetComponent<GlobalRandomMultiplier>().GenerateRandomNumber();
            DamageNumbers.instance.Create(gameObject.GetComponent<Transform>().position, Mathf.RoundToInt(healValue * randomNumber), 1);
            other.GetComponentInParent<PlayerController2D>().DoHeal(healValue * randomNumber);
            hasTriggered = true;
        }
    }
    public void FadeAway()
    {
        isFading = true;
    }
}
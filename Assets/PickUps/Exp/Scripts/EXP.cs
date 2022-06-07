using UnityEngine;


public class EXP : MonoBehaviour
{
    public float expValue;
    public AudioSource audioSource;
    public AudioClip Bwip;
    public float volume = 1f;
    private GameObject target;
    void Start()
    {
        Destroy(gameObject, 20f);
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        target = GameHandler.instance.player;
        Vector3 adjusted = target.transform.position + new Vector3(0,-.14f);
        var distanceDifference = Vector3.Distance(adjusted, transform.position);
        if (distanceDifference <= .07)
        {
            AudioSource.PlayClipAtPoint(Bwip, transform.position);
            Collected();
            //GetComponent<AudioSource>().PlayOneShot(Bwip);
            target.gameObject.GetComponentInParent<PlayerController2D>().ExpCollected(expValue);
        }
    }
}
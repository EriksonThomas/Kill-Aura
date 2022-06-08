using UnityEngine;


public class EXP : MonoBehaviour
{
    public float expElement;
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
        if(expElement == 0)
        {
            GameHandler.instance.player.GetComponent<PlayerStats>().normalEnemyMeter += 1;
        } 
        else if(expElement == 1)
        {
            GameHandler.instance.player.GetComponent<PlayerStats>().eliteEnemyMeter += 1;
        }  
        else if(expElement == 2)
        {
            GameHandler.instance.player.GetComponent<PlayerStats>().bossEnemyMeter += 1;
        }

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
            target.gameObject.GetComponentInParent<PlayerController2D>().ExpCollected(expElement);
        }
    }
}
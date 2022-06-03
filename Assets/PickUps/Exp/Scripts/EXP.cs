using UnityEngine;
public class EXP : MonoBehaviour
{
    public float expValue = 10.0f;
    void Start()
    {
        Destroy(gameObject, 20f);
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
            other.gameObject.GetComponentInParent<PlayerController2D>().ExpCollected(expValue);
        }
    }
}
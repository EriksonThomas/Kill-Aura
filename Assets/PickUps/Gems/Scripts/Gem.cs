using UnityEngine;
public class Gem : MonoBehaviour
{
    public float gemValue;
    private GameObject target;
    void Start()
    {
        target = GameObject.Find("Player");
        Destroy(gameObject, 15f);
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        var distanceDifference = Vector3.Distance(target.transform.position, transform.position);
        if (distanceDifference <= .15)
        {
            Collected();
            target.gameObject.GetComponentInParent<PlayerController2D>().GemCollected(gemValue);
        }
    }
}
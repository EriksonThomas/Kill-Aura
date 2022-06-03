using UnityEngine;
public class Gem3 : MonoBehaviour
{
    public float gemValue = 25.0f;
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
        if (distanceDifference <= .03)
        {
            Collected();
            target.gameObject.GetComponentInParent<PlayerController2D>().GemCollected(gemValue);
        }
    }
}
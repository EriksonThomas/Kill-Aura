using UnityEngine;
public class EXP2 : MonoBehaviour
{
    public float expValue = 50.0f;
    private GameObject target;
    void Start()
    {
        target = GameObject.Find("Player");
        Destroy(gameObject, 20f);
    }
    public void Collected()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        var distanceDifference = Vector3.Distance(target.transform.position, transform.position);
        if (distanceDifference <= .07)
        {
            Collected();
            target.gameObject.GetComponentInParent<PlayerController2D>().ExpCollected(expValue);
        }
    }
}
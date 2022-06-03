using UnityEngine;
public class EXP1 : MonoBehaviour
{
    public float expValue = 10.0f;
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
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public float orbitSpeed = 0.0f;
    private float angle = 0.0f;
    public float orbitDistance = 0.0f;
    private GameObject orbitTarget;
    void Start()
    {
        orbitTarget = GameObject.Find("Player");
    }
    void Update()
    {
        //Do some trig to figure out a vector3 to orbit the player
        angle += Time.deltaTime * orbitSpeed;
        transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * orbitDistance + orbitTarget.transform.position;
        gameObject.transform.rotation = Quaternion.identity;
    }
}

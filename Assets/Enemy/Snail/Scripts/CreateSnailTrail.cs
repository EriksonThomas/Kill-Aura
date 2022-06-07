using UnityEngine;
public class CreateSnailTrail : MonoBehaviour
{
    public GameObject snailTrail;
    private float snailTrailTimer = 0;
    public GameObject[] trailList = new GameObject[500];
    private int ballCounter = 0;
    void Start()
    {
        trailList = new GameObject[500];
    }
    void Update()
    {
        if (snailTrailTimer > 0)
        {
            snailTrailTimer -= Time.deltaTime;
        }
        else
        {
            AddTrailBall(ballCounter);
            ballCounter += 1;
            snailTrailTimer = 0.1f;
        }
    }
    void AddTrailBall(int ballCounter)
    {
        var pos = gameObject.GetComponent<Transform>().position;
        pos.y = pos.y - 0.14f;
        trailList[ballCounter] = Instantiate(snailTrail, pos, Quaternion.identity) as GameObject; 
        // Debug.Log(trailList[ballCounter]);
    }  
}

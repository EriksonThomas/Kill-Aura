using UnityEngine;

public class GemFollowPlayer : MonoBehaviour
{
    public float moveSpeed;
    public GameObject target;
    private Vector3 randomDir;
    private Vector3 lastTargetPos;
    void Start()
    {
        target = GameHandler.instance.player;
    }
    void Update()
    {
        Vector3 adjusted = target.transform.position + new Vector3(0,-.14f);
        //calculate distance between the target and the object following
        var distanceDifference = Vector3.Distance(adjusted, transform.position);
        if(distanceDifference >= 0.0f && distanceDifference < 1.0f)
        {
            Vector3 dir = adjusted - transform.position;
            //speed exp balls up as they approach the target
            transform.position += dir.normalized * ((1 / distanceDifference) * .2f) * Time.deltaTime;
        }
    }
}

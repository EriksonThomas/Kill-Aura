using UnityEngine;

public class BaseAttackAnimation : MonoBehaviour
{
    private float time = 0.0f;
    public float maxTime = 20f;
    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
public class BaseAttackAnimation : MonoBehaviour
{
    void FixedUpdate()
    {
        Destroy(gameObject, 0.1f);
    }
}

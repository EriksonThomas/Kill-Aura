using UnityEngine;
public class HealingPoolEffect : MonoBehaviour
{
    public float healPerSec = 6f;
    [SerializeField] BaseEffect Effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var effectableObject = other.GetComponent<EffectableObject>();
            if (effectableObject != null)
            {
                effectableObject.ApplyEffect(Effect);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var effectableObject = other.GetComponent<EffectableObject>();
            if (effectableObject != null)
            {
                effectableObject.RemoveAllOfEffect(Effect);
            }
        }
    }
}
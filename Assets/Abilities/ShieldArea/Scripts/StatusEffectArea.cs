using UnityEngine;
public class StatusEffectArea : MonoBehaviour
{
    [SerializeField] BaseEffect Effect;
    public bool removeWhenLeaves = false;

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
        if (other.gameObject.tag == "Player" && removeWhenLeaves)
        {
            var effectableObject = other.GetComponent<EffectableObject>();
            if (effectableObject != null)
            {
                effectableObject.RemoveAllOfEffect(Effect);
            }
        }
    }
}
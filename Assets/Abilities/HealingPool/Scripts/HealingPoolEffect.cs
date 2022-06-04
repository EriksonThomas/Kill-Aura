using UnityEngine;
public class HealingPoolEffect : MonoBehaviour
{
    public float healPerSec = 6f;
    [SerializeField] BaseEffect Effect;
    public bool playerIsIn = false; // true if a player with an effectableObject is in the area
    private EffectableObject playerEffectable; // store to remove effect when this is destroyed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var effectableObject = other.GetComponent<EffectableObject>();
            if (effectableObject != null)
            {
                playerIsIn = true;
                playerEffectable = effectableObject;
                effectableObject.ApplyEffect(Effect);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIsIn = false;
            var effectableObject = other.GetComponent<EffectableObject>();
            if (effectableObject != null)
            {
                effectableObject.RemoveAllOfEffect(Effect);
            }
        }
    }

    private void OnDestroy()
    {
        if (playerIsIn)
        {
            playerEffectable.RemoveAllOfEffect(Effect);
        }
    }
}
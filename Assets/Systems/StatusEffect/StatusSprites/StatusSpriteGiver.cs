using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSpriteGiver : MonoBehaviour
{
    public float spacing = 15;
    private EffectableObject playerEffectable;
    private List<GameObject> activeSprites = new List<GameObject>();
    private GameObject target;
    void Start()
    {
        target = gameObject;    
        playerEffectable = gameObject.GetComponent<EffectableObject>();
    }
    void Update()
    {
        UpdateStatusSprites();
    }
    void UpdateStatusSprites()
    {
        if (playerEffectable.statusSpriteHasSeen == false)
        {
            // kill all child icons
            foreach (GameObject sprite in activeSprites)
            {
                GameObject.Destroy(sprite);
            }
            activeSprites = new List<GameObject>();

            // instantiate icon for each
            float start = -1f * (playerEffectable.activeEffects.Count * spacing / 2f);

            for (int i = 0; i < playerEffectable.activeEffects.Count; ++i)
            {
                if (playerEffectable.activeEffects[i].statusSprite!= null)
                {
                GameObject statusSprite = Instantiate(playerEffectable.activeEffects[i].statusSprite);
                statusSprite.transform.SetParent(target.transform);
                statusSprite.transform.position = target.transform.position;
                
                activeSprites.Add(statusSprite);
                }
            }

            playerEffectable.statusSpriteHasSeen = true;
        }
    }
}

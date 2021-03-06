using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarBehavior : MonoBehaviour
{
    public float spacing = 15;
    private EffectableObject playerEffectable;
    private List<GameObject> effectIcons = new List<GameObject>();
    private GameObject target;

    void Update()
    {
        UpdateStatusIcons();
    }
    void UpdateStatusIcons()
    {
        playerEffectable = GameHandler.instance.player.GetComponent<EffectableObject>();

        if (playerEffectable.statusBarHasSeen == false)
        {
            // kill all child icons
            foreach (GameObject icon in effectIcons)
            {
                GameObject.Destroy(icon);
            }
            effectIcons = new List<GameObject>();

            // instantiate icon for each
            float start = -1f * (playerEffectable.activeEffects.Count * spacing / 2f);

            for (int i = 0; i < playerEffectable.activeEffects.Count; ++i)
            {
                GameObject icon = Instantiate(playerEffectable.activeEffects[i].icon);
                icon.transform.SetParent(gameObject.transform);
                icon.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(start + (i * spacing), 0);
                
                effectIcons.Add(icon);
            }

            playerEffectable.statusBarHasSeen = true;
        }
    }
}

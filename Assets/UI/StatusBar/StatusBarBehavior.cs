using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarBehavior : MonoBehaviour
{
    public float spacing = 15;
    private EffectableObject playerEffectable;
    private List<GameObject> effectIcons = new List<GameObject>();

    void Start()
    {
        playerEffectable = GameObject.Find("Player").GetComponent<EffectableObject>();
    }

    // GameObject AddStatusIcon(GameObject icon)
    // {
    //     if (icon != null)
    //     {
    //         GameObject newIcon = Instantiate(icon);
    //         effectIcons.Add(newIcon);
    //         UpdateStatusEffectPositions();

    //         return (newIcon);
    //     }
    //     return (null);
    // }

    void Update()
    {
        UpdateStatusIcons();
    }
    void UpdateStatusIcons()
    {
        if (playerEffectable.statusBarHasSeen == false)
        {
            // kill all child icons
            foreach (GameObject icon in effectIcons)
            {
                GameObject.Destroy(icon);
            }

            // instantiate icon for each
            float start = -1f * (transform.childCount * spacing / 2f);

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

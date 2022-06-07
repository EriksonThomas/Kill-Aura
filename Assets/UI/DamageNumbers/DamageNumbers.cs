using UnityEngine;
using TMPro;
public class DamageNumbers : MonoBehaviour
{
    public GameObject textObject;
    public static DamageNumbers instance;
    public void Awake()
    {
        instance = this;
    }
    public void Create(Vector3 pos, int dmg)
    {
        GameObject damageNumberObject = Instantiate(textObject, pos, Quaternion.identity);
        damageNumberObject.GetComponent<TextMeshPro>().SetText(dmg.ToString());
    }
}
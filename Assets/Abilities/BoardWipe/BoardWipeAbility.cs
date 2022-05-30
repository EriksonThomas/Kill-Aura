using UnityEngine;
public class BoardWipeAbility : MonoBehaviour
{
    public bool boardWipe = true;
    public float boardWipeInterval = 10f;
    private float boardWipeRangeExponent = 4f;
    public float boardWipeDuration = 0.5f;
    public GameObject attackBoardWipeObject;
    private Vector3 randomVector;
    private GameObject target;

    void Start()
    {
        InvokeRepeating("BoardWipeAttack", 1, boardWipeInterval);
    }

    public void BoardWipeAttack()
    {
        target = GameObject.Find("Player");
        GameObject clone = Instantiate(attackBoardWipeObject, target.transform.position, Quaternion.identity);
        Destroy(clone, boardWipeDuration);
    }

    
}
        
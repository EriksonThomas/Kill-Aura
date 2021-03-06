using UnityEngine;
public class BoardWipeAbility : MonoBehaviour
{
    public bool boardWipe = true;
    public float boardWipeInterval = 5f;
    public float boardWipeDuration = 0.5f;
    public GameObject attackBoardWipeObject;
    private GameObject target;
    void Start()
    {
        InvokeRepeating("BoardWipeAttack", 1, boardWipeInterval);
    }
    public void BoardWipeAttack()
    {
        target = GameHandler.instance.player;
        GameObject clone = Instantiate(attackBoardWipeObject, target.transform.position, Quaternion.identity);
        Destroy(clone, boardWipeDuration);
    }
}
        
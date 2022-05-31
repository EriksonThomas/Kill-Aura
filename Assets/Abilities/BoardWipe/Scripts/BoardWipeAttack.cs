using UnityEngine;
public class BoardWipeAttack : MonoBehaviour
{
    public float BoardWipeDamage = 100f;
void Start()
{
    Debug.Log("BoardWipe");
}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponentInParent<EnemyController>().DamageTaken(BoardWipeDamage);
        }
    }
}
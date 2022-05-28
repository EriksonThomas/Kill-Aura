using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    private float attackDelay;
    public float startAttackDelay;
    public Transform attackRightPosition;
    public Transform attackLeftPosition;
    public Transform attackUpPosition;
    public Transform attackDownPosition;
    public LayerMask whatIsEnemies;
    public GameObject baseAttackAnimation;
    public float attackRange;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackDelay <= 0)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                Attack(attackLeftPosition);
                Instantiate(baseAttackAnimation, attackLeftPosition.position, Quaternion.identity);
            }

            if(Input.GetKey(KeyCode.RightArrow))
            {
                Attack(attackRightPosition);
                Instantiate(baseAttackAnimation, attackRightPosition.position, Quaternion.identity);
            } 

            if(Input.GetKey(KeyCode.UpArrow))
            {
                Attack(attackUpPosition);
                Instantiate(baseAttackAnimation, attackUpPosition.position, Quaternion.identity);
            }

            if(Input.GetKey(KeyCode.DownArrow))
            {
                Attack(attackDownPosition);
                Instantiate(baseAttackAnimation, attackDownPosition.position, Quaternion.identity);
            }

            attackDelay = startAttackDelay;
        }
        else{
            attackDelay -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRightPosition.position,attackRange);
        Gizmos.DrawWireSphere(attackLeftPosition.position,attackRange);
        Gizmos.DrawWireSphere(attackUpPosition.position,attackRange);
        Gizmos.DrawWireSphere(attackDownPosition.position,attackRange);
    }
    void Attack(Transform attackDirection)
    {
        Debug.Log("Attack" + attackDirection);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackDirection.position, attackRange, whatIsEnemies);
        for(int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyController>().DamageTaken(attackDamage);
        }
    }
}

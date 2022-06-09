using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    public float moveSpeed;
    public float moveSpeedStart;
    public float maxHealth;
    public float currentHealth;
    public float healthRegenTime;
    public float attackDamage;
    public float dazeTime;
    public float dazeCounter;
    public int expDropped;
    public void ScaleEnemy(int waveNumber)
    {
        if(waveNumber != 1)
        {
            ScaleAttackDamage(waveNumber);
            ScaleHealth(waveNumber);
            ScaleSpeed(waveNumber);
        }
    }
    public void ScaleAttackDamage(int waveNumber)
    {
        Debug.Log("Attack Damage");
        attackDamage = attackDamage + (waveNumber / 6.0f);
    }
    public void ScaleHealth(int waveNumber)
    {
        Debug.Log("Scale Health");
        maxHealth = maxHealth + (waveNumber / 2.0f);
        currentHealth = currentHealth + (waveNumber / 2.0f);
    }
    public void ScaleSpeed(int waveNumber)
    {
        Debug.Log("Scale Speed");
        Debug.Log(moveSpeed = moveSpeed + (waveNumber / 9.0f));
        moveSpeedStart = moveSpeedStart + (waveNumber / 9.0f);
        moveSpeed = moveSpeed + (waveNumber / 9.0f);
    }
}
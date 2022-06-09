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
        ScaleAttackDamage(waveNumber);
        ScaleHealth(waveNumber);
        ScaleSpeed(waveNumber);
    }
    public void ScaleAttackDamage(int waveNumber)
    {
        attackDamage = attackDamage + (waveNumber / 6.0f);
    }
    public void ScaleHealth(int waveNumber)
    {
        maxHealth = maxHealth + (waveNumber / 2.0f);
        currentHealth = currentHealth + (waveNumber / 2.0f);
    }
    public void ScaleSpeed(int waveNumber)
    {
        moveSpeed = moveSpeed + (waveNumber / 2.0f);
        moveSpeedStart = moveSpeed;
    }
}
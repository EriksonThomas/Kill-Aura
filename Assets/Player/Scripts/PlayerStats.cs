using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float healthRegenTime;
    public float maxStamina;
    public float currentStamina;
    public float staminaRegenTime;
    public float attackDamage;
    public int normalEnemyMeter;
    public int eliteEnemyMeter;
    public int bossEnemyMeter;
    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(normalEnemyMeter + eliteEnemyMeter + bossEnemyMeter);
    }
}

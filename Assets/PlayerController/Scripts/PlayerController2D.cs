using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth = 10f;
    public float healthRegenTime = 2f;
    public float maxStamina = 20f;
    public float currentStamina = 20f;
    public float staminaRegenTime = 2f;
    public float startingGems = 0.0f;

    void FixedUpdate()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegenTime * Time.fixedDeltaTime;
        }
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenTime * Time.fixedDeltaTime;
        }
        
        

        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            //TODO: death animation here
        }
    }
    public void DamageTaken(float damage)
    {
        currentHealth -= damage;
    } 
}

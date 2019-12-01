using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    int healthPowerCollectCount = 0;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    public void HealthPowerUp()
    {
        switch(healthPowerCollectCount)
        {
            case 0 :
                health.currentHealth = health.currentHealth + 5;
                healthPowerCollectCount++;
                break;

            case 1 :
                health.currentHealth = health.currentHealth + 10;
                healthPowerCollectCount++;
                break;

            default :
                if(health.currentHealth <= 200)
                {
                    health.currentHealth = health.currentHealth + 20;
                }
                break;
        }
    }
}

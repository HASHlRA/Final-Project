using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    PlayerHealth playerHealth;

    public float healthBonus = 10;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.life < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.life = playerHealth.life + healthBonus;
        }
    }
}

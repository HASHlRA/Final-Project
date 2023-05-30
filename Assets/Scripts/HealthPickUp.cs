using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    PlayerHealth playerHealth;

    public float healthBonus = 10;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.Life < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.Life = playerHealth.Life + healthBonus;
        }
    }
}

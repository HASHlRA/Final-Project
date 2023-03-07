using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float life;

    [SerializeField] public float maxHealth;

    [SerializeField] private HealthBar healthBar;

    public event EventHandler PlayerDeath;

    private void Start()
    {
        life = maxHealth;
        healthBar.StartHealthBar(life);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        healthBar.ChangeActualHealth(life);
        if (life <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            //Destroy(gameObject);
        }
    }
}

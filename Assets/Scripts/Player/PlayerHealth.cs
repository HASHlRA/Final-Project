using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float life;

    public event EventHandler PlayerDeath;

    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            //Destroy(gameObject);
        }
    }
}

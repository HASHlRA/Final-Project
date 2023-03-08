using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float life;

    [SerializeField] public float maxHealth;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private SimpleFlash flashEffect;

    public event EventHandler PlayerDeath;

    //Audio

    private AudioSource audiosource;

    [SerializeField] private AudioClip AudioDamage;

    private void Start()
    {
        life = maxHealth;
        healthBar.StartHealthBar(life);
        audiosource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        healthBar.ChangeActualHealth(life);
        flashEffect.Flash();
        audiosource.PlayOneShot(AudioDamage);

        if (life <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            //Destroy(gameObject);
            SetMaxHealth();
            
        }
    }

    public void SetMaxHealth()
    {
        life = maxHealth;
        healthBar.ChangeActualHealth(life);
    }
}

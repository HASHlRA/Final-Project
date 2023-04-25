using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float life;

    public float Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            healthBar.ChangeActualHealth(value);
        }
    }

    [SerializeField] public float maxHealth;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private SimpleFlash flashEffect;

    public event EventHandler PlayerDeath;

    //Audio

    private AudioSource audiosource;

    [SerializeField] private AudioClip AudioDamage;

    private void Start()
    {
        Life = maxHealth;
        healthBar.StartHealthBar(Life);
        audiosource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;
        healthBar.ChangeActualHealth(Life);
        flashEffect.Flash();
        audiosource.PlayOneShot(AudioDamage);

        if (Life <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            //Destroy(gameObject);
            SetMaxHealth();
            
        }
    }

    public void SetMaxHealth()
    {
        Life = maxHealth;
        healthBar.ChangeActualHealth(Life);
    }
}

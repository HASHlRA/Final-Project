using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    PlayerHealth playerHealth;
    [SerializeField] private AudioClip heal;
    private AudioSource audiosource;

    public float healthBonus = 10;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.Life < playerHealth.maxHealth)
        {
            audiosource.PlayOneShot(heal);

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;

            playerHealth.Life = playerHealth.Life + healthBonus;
        }
    }
}

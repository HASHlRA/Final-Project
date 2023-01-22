using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform player;

    private bool lookingRight = true;


    [Header("Life")]

    [SerializeField] private float health;

    [SerializeField] private HealthBar healthBar;



    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        healthBar.StartHealthBar(health);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.ChangeActualHealth(health);

        if (health <= 0)
        {
            animator.SetTrigger("Death");
        }
    }


    private void Death()
    {
        Destroy(gameObject);
    }


    public void LookPlayer()
    {
        if ((player.position.x > transform.position.x && !lookingRight) || (player.position.x < transform.position.x && lookingRight))
        {
            lookingRight = !lookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}

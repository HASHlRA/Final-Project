using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private Transform hitController;

    [SerializeField] private float hitbox;

    [SerializeField] private float damage;

    [SerializeField] private float timeBetweenAttack;

    [SerializeField] private float attackCooldown;


    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Attack") && attackCooldown <= 0)
        {
            Hit();
            attackCooldown = timeBetweenAttack;
        }
    }


    private void Hit()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objects = Physics2D.OverlapCircleAll(hitController.position, hitbox);

        foreach (Collider2D collision in objects)
        {
            if(collision.CompareTag("Enemy"))
            {
                collision.transform.GetComponent<Enemy>().GetDamage(damage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitController.position, hitbox);
        
    }
}

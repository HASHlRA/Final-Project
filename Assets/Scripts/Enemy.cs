using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;

    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GetDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Death();
        }
    }


    private void Death()
    {
        animator.SetTrigger("Death");
    }
}

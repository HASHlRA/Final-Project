using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private Vector2 boxDimensions;

    [SerializeField] private Transform boxPosition;

    [SerializeField] private float healthTime;


    private void Start()
    {
        Destroy(gameObject, healthTime);
    }

    public void Hit()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(boxPosition.position, boxDimensions, 0f);

        foreach (Collider2D collisions in objects)
        {
            if (collisions.CompareTag("Player"))
            {
                collisions.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxPosition.position, boxDimensions);
    }
}

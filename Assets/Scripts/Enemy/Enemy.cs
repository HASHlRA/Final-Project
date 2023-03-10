using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;

    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform player;

    private bool dead;

    private bool attack;

    [SerializeField] private bool lookingRight;

    private float distancePlayer;

    [SerializeField] private SimpleFlash flasheffect;

    [Header("Attack")]

    [SerializeField] private Transform attackController;

    [SerializeField] private float attackRadius;

    [SerializeField] private float attackDamage;

    // Audio

    private AudioSource audiosource;

    [SerializeField] private AudioClip AudioDamaged;
    [SerializeField] private AudioClip AudioAttack;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        distancePlayer = Vector2.Distance(transform.position, player.position);
        
        LookPlayer();
    }

    private void LateUpdate()
    {
        animator.SetFloat("distancePlayer", distancePlayer);
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        flasheffect.Flash();
        audiosource.PlayOneShot(AudioDamaged);

        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Puerta").GetComponent<GoToScene>().EnemyDestroyed();
            Death();
            StartCoroutine(Destroy());
        }
    }


    private void Death()
    {
        animator.SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        dead = true;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void LookPlayer()
    {
        if (((player.position.x > transform.position.x && !lookingRight) || (player.position.x < transform.position.x && lookingRight)) && !dead && !attack)
        {
            lookingRight = !lookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Attack()
    {
        audiosource.PlayOneShot(AudioAttack);

        attack = true;

        StartCoroutine(Freeze());

        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);

        foreach (Collider2D collision in objects)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
    }

    IEnumerator Freeze()
    {
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(1.5f);

        rb2D.constraints = ~RigidbodyConstraints2D.FreezePosition;

        attack = false;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }
}

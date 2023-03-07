using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    private Animator animator;

    public Rigidbody2D rb2D;

    public Transform player;

    [SerializeField] private bool lookingRight;


    [Header("Life")]

    [SerializeField] private float health;

    [SerializeField] public HealthBar healthBar;



    [Header("Attack")]

    [SerializeField] private Transform attackController;

    [SerializeField] private float attackRadius;

    [SerializeField] private float attackDamage;

    [SerializeField]private bool attack;

    public string sceneName;

    [SerializeField] private SimpleFlash flashEffect;

    // Audio

    private AudioSource audiosource;

    [SerializeField] private AudioClip AudioDamaged;
    [SerializeField] private AudioClip AudioAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        healthBar.StartHealthBar(health);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audiosource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        float distancePlayer = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("distancePlayer", distancePlayer);
        LookPlayer();
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        audiosource.PlayOneShot(AudioDamaged);

        healthBar.ChangeActualHealth(health);

        flashEffect.Flash();


        if (health <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(GoNextScene());
        }
    }



    private IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }


    public void LookPlayer()
    {
        if ((player.position.x > transform.position.x && !lookingRight) || (player.position.x < transform.position.x && lookingRight) &&!attack)
        {
            lookingRight = !lookingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Attack()
    {
        attack = true;

        audiosource.PlayOneShot(AudioAttack);

        StartCoroutine(AttackCooldown());


        Collider2D[] objects = Physics2D.OverlapCircleAll(attackController.position, attackRadius);

        foreach (Collider2D collision in objects)
        {
            if(collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        
        yield return new WaitForSeconds(0.5f);
        attack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackController.position, attackRadius);
    }
}

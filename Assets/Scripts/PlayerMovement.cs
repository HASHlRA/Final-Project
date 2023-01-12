using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float horizontalMovement = 0f;
    [SerializeField] private float velocityMovement;
    [Range (0, 0.3f)] [SerializeField] private float smoothness;
    private Vector3 velocity = Vector3.zero;
    private bool right = true;

    [Header("Jump")]
    [SerializeField] private float jumpforce;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundcontrol;
    [SerializeField] private Vector3 boxdimensions;
    [SerializeField] private bool onGround;

    private bool jump = false;


    [Header("Animation")]
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * velocityMovement;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));

        animator.SetFloat("VelocityY", rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    private void Fixedupdate()
    {
        onGround = Physics2D.OverlapBox(groundcontrol.position, boxdimensions, 0f, ground);
        animator.SetBool("onGround", onGround);

        //Move
        Move(horizontalMovement * Time.fixedDeltaTime, jump);

        jump = false;
    }

    private void Move(float move, bool jump)
    {
        Vector3 objectVelocity = new Vector2(move, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, objectVelocity, ref velocity, smoothness);

        if(move > 0 && right)
        {
            //turn
            turn();
        }

        if (move < 0 && right)
        {
            //turn
            turn();
        }

        if(onGround && jump)
        {
            onGround = false;
            rb2D.AddForce(new Vector2(0f, jumpforce));
        }
    }

    private void turn()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundcontrol.position, boxdimensions);
    }
}

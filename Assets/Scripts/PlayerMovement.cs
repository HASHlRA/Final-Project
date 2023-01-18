using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float inputX;
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



    [Header("WallJump")]

    [SerializeField] private Transform wallcontrol;
    [SerializeField] private Vector3 wallboxdimensions;
    private bool onWall;
    public bool slide;
    [SerializeField] private float slideVelocity;
    [SerializeField] private float wallJumpForceX;
    [SerializeField] private float wallJumpForceY;
    [SerializeField] private float cooldownWallJump;

    private bool jumpingWall;



    [Header("Dash")]

    [SerializeField] private float dashVelocity;
    [SerializeField] private float dashTime;
    [SerializeField] private TrailRenderer trailRenderer;

    private float initialGravity;

    private bool canDash = true;

    private bool canMove = true;




    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialGravity = rb2D.gravityScale;
    }


    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        horizontalMovement =  inputX * velocityMovement;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));
        animator.SetFloat("VelocityY", rb2D.velocity.y);

        animator.SetBool("Slide", slide);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X) && canDash && onGround)
        {
            StartCoroutine(Dash());
        }

        if(!onGround && onWall && inputX !=0)
        {
            slide = true;
        }
        else
        {
            slide = false;
        }

    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapBox(groundcontrol.position, boxdimensions, 0f, ground);
        animator.SetBool("onGround", onGround);

        onWall = Physics2D.OverlapBox(wallcontrol.position, wallboxdimensions, 0f, ground);


        //Move
        if (canMove)
        {
            Move(horizontalMovement * Time.fixedDeltaTime, jump);
        }

        jump = false;

        if(slide)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, Mathf.Clamp(rb2D.velocity.y, -slideVelocity, float.MaxValue));
        }
    }

    private void Move(float move, bool jump2)
    {
        if (!jumpingWall)
        {
            Vector3 objectVelocity = new Vector2(move, rb2D.velocity.y);
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, objectVelocity, ref velocity, smoothness);
        }

        

        if (move > 0 && !right)
        {
            //turn
            turn();
        }

        if (move < 0 && right)
        {
            //turn
            turn();
        }

        if(jump2 && onGround && !slide)
        {
            Jump();
        }

        if (jump2 && onWall && slide)
        {
            //WallJump
            WallJump();
        }
    }


    private void WallJump()
    {
        onWall = false;
        rb2D.velocity = new Vector2(wallJumpForceX * -inputX, wallJumpForceY);
        //Wait
        StartCoroutine(ChangeWallJump());
    }

    IEnumerator ChangeWallJump()
    {
        jumpingWall = true;
        yield return new WaitForSeconds(cooldownWallJump);
        jumpingWall = false;
    }

    private void Jump()
    {
        onGround = false;
        rb2D.AddForce(new Vector2(0f, jumpforce));
    }


    private void turn()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    private IEnumerator Dash()
    {
        canMove = false;
        canDash = false;
        rb2D.gravityScale = 0;
        rb2D.velocity = new Vector2(dashVelocity * transform.localScale.x, 0);
        animator.SetTrigger("Dash");
        trailRenderer.emitting = true;

        yield return new WaitForSeconds(dashTime);

        canMove = true;
        canDash = true;
        rb2D.gravityScale = initialGravity;
        trailRenderer.emitting = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundcontrol.position, boxdimensions);
        Gizmos.DrawWireCube(wallcontrol.position, wallboxdimensions);
    }
}

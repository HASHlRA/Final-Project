using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform floorController;

    [SerializeField] private float distance;

    [SerializeField] private bool movingRight;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D floorInfo = Physics2D.Raycast(floorController.position, Vector2.down, distance);

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if(floorInfo == false)
        {
            Turn();
        }
    }

    private void Turn()
    {
        movingRight = !movingRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(floorController.transform.position, floorController.transform.position + Vector3.down);
    }
}

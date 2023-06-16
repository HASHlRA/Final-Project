using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRaycast : MonoBehaviour
{

    public float distance;
    RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(this.transform.forward, Vector2.right, distance);

        Debug.DrawRay(this.transform.forward, Vector2.right*distance,Color.blue);

        if (hit.collider.tag == "Ground")
        {
            Debug.Log("hola");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        offset = (playerRB.velocity.x * 0.1f) * velocity * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}

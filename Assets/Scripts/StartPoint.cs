using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string uuid; // uuid = universal uniqued identifier
    private PlayerMovement player;
    [SerializeField] private Vector2 facingDirection;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (!player.nextUuid.Equals(uuid))
        {
            return;
        }

        player.transform.position = transform.position;
    }

}

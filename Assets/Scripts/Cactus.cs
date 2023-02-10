using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Cactus : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Detect collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player died; Do end scene here");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
    }
}

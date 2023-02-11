using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 1;
    private Rigidbody2D rb;
    private CircleCollider2D groundTrigger;
    private BoxCollider2D hitbox;
    private bool canJump, isJumping;
    private SpriteRenderer render;
    public Sprite standSprite, duckSprite;

    public GameObject button;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundTrigger = GetComponent<CircleCollider2D>();
        button.SetActive(false);
        Time.timeScale = 1f;
        hitbox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump &!Input.GetKey(KeyCode.LeftShift))
        {
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) &! Input.GetKeyDown(KeyCode.Space))
        {
            hitbox.size = new Vector2(0.8f, 0.45f);
            render.sprite = duckSprite;
        }
        else
        {
            hitbox.size = new Vector2(0.8f, 0.9f);
            render.sprite = standSprite;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            rb.velocity = Vector2.up * jumpPower;
            isJumping = false;
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) canJump = true;

        if (collision.gameObject.CompareTag("Cactus"))
        {
            Time.timeScale = 0f;

            button.SetActive(true);
        }
    }
}

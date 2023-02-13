using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpPower = 1;
    public Sprite standSprite, duckSprite;
    public GameObject button;

    private Rigidbody2D rb;
    private bool canJump, isJumping;
    private BoxCollider2D hitbox;
    private SpriteRenderer render;
    private bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        button.SetActive(false);
        Time.timeScale = 1f;
        hitbox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) && canJump & !Input.GetKey(KeyCode.LeftShift))
        {
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) & !Input.GetKeyDown(KeyCode.Space))
        {
            hitbox.size = new Vector2(0.8f, 0.45f);
            hitbox.offset = new Vector2(0, -0.225f);
            render.sprite = duckSprite;
        }
        else
        {
            hitbox.size = new Vector2(0.8f, 0.9f);
            hitbox.offset = Vector2.zero;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cactus"))
        {
            Time.timeScale = 0f;
            isDead = true;

            button.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}

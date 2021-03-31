using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SlimeMovingAI : MonoBehaviour
{
    private float speed = 1f;
    private float direction = -1f;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        enabled = false;
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnBecameVisible()
    {
        enabled = true;
    }


    void Update()
    {
        rigidBody2D.velocity = new Vector2(direction * speed, rigidBody2D.velocity.y);

        if (direction < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (!collision.gameObject.CompareTag("Base") && !collision.gameObject.CompareTag("player") && !collision.gameObject.CompareTag("questionBlock"))
        {
            direction *= -1;
        }
        if (collision.gameObject.CompareTag("plant"))
        {
            Destroy(gameObject);
        }
    }
}

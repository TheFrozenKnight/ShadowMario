using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SlimeMovingAI : MonoBehaviour
{
    private float speed = 2f;
    private float direction = -1f;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
        if (collision.gameObject.tag != "Base" && collision.gameObject.tag != "player")
        {
            direction *= -1;
        }
    }
}

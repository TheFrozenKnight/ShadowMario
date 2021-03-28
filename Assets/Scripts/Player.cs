using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpspeed = 6f;
    private bool Isgrounded = true;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //float jump = Input.GetAxis("Jump");

        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);
        if(h!=0 && Isgrounded)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }
        if( Input.GetKeyDown(KeyCode.Space) && Isgrounded == true) 
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            animator.SetBool("jumping", true);
        }

        if (h < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(h > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
        if (collision.gameObject.tag == "enemy")
        {
            if (direction.y == 1)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                SceneManager.LoadScene("Lvl1_1");
            }
        }
        if (collision.gameObject.tag == "plant")
        {
            SceneManager.LoadScene("Lvl1_1");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "pipe")
        { 
            Isgrounded = true;
            animator.SetBool("jumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "pipe")
            Isgrounded = false;
    }
}

/*
void OnCollisionEnter(Collision c)
   {
      Vector2 direction = c.GetContact(0).normal;
      If( direction.x == 1 ) print(“right”);
      If( direction.x == -1 ) print(“left”);
      If( direction.y == 1 ) print(“up”);
      If( direction.y == -1 ) print(“down”);
   }
if (collision.gameObject.tag == "collectibles")
    {
        Destroy(collision.gameObject);
        score++;
        scoreText.text = ("Score: " + score);
    }
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpspeed = 5f;
    private bool Isgrounded = true;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    public Sprite jumpSprite;
    public Sprite idleSprite;
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
        rigidBody2D.velocity = new Vector2(h * speed, rigidBody2D.velocity.y);
        if(h!=0 && Isgrounded)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && Isgrounded == true)
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
   /* private bool isGrounded()
    {
        return Isgrounded();
    }*/
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
        { 
            Isgrounded = true;
            animator.SetBool("jumping", false);
        }
        

        if (collision.gameObject.tag == "enemy")
            Debug.Log("Collision with plant");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Base")
            Isgrounded = false;
    }
}

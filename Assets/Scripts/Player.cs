﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpspeed = 6f;
    private bool Isgrounded = true;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public AudioSource audioSource;
    public static int score = 0;
    public static int coins = 0;
    public static int lives = 3;
    public AudioClip[] sounds = new AudioClip[5];

    void Start()
    {
        score = 0;
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
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
        if( Input.GetKeyDown(KeyCode.Space) && Isgrounded == true) 
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpspeed);
            audioSource.clip = sounds[0];
            audioSource.Play();
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
        if (collision.gameObject.CompareTag("enemy"))
        {
           
            if (direction.y == 1)
            {
                score+=200;
                Destroy(collision.gameObject);
                audioSource.clip = sounds[2];
                audioSource.Play();
            }
            else
            {
                lives--;
                SceneManager.LoadScene("Lvl1_1");
            }
        }
        if (collision.gameObject.CompareTag("plant"))
        {
            lives--;
            SceneManager.LoadScene("Lvl1_1");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") || collision.gameObject.CompareTag("pipe") || collision.gameObject.CompareTag("questionBlock"))
        {
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y) && direction.y > 0)
            {
                Isgrounded = true;
                animator.SetBool("jumping", false);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base") || collision.gameObject.CompareTag("pipe") || collision.gameObject.CompareTag("questionBlock"))
            Isgrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CollectableCoin"))
        {
            score+=100;
            coins++;
            audioSource.clip = sounds[1];
            audioSource.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("END"))
        {
            SceneManager.LoadScene("Win");
        }
    }
}
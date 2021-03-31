using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject cam;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Player.score+=1000;
            cam.GetComponent<AudioSource>().enabled = false;
            audioSource.Play();
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}

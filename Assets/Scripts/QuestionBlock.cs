using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public int coins = 1;
    public Sprite questionOff;
    public GameObject CoinBox;
    public static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Vector2 direction = collision.GetContact(0).normal;

            if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y))
            {
                if (direction.y > 0)
                {
                    if (coins > 0)
                    {
                        (Instantiate(CoinBox) as GameObject).transform.parent = this.gameObject.transform;
                        coins--;
                        audioSource.Play();
                        Player.score++;
                    }
                    if (coins == 0)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = questionOff;
                    }
                }
            }
        }
    }
}

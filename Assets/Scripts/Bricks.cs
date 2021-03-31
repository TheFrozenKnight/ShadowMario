using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Vector2 direction = collision.GetContact(0).normal;

            if (Mathf.Abs(direction.x) <= Mathf.Abs(direction.y))
            {
                if (direction.y > 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

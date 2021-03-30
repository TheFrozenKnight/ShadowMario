using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public int coins = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
        if (direction.y == 1)
        {
            if(coins>0)
            {
                //spawn coin
                coins--;
                Player.score++;
            }
            if (coins == 0)
            {
                //change sprite to questionOff
            }
        }
    }
}

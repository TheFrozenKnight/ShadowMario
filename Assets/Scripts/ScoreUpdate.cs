using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static int temp = 0;
    void Start()
    {
        temp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.score != temp)
        {
            temp = Player.score;
            this.gameObject.GetComponent<Text>().text = ("SCORE: " + Player.score);
        }
    }
}

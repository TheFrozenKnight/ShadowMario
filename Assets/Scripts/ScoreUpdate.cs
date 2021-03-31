using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static int temp = 0;
    void Start()
    {
        temp = 0;
    }

    void Update()
    {
        if(Player.score != temp)
        {
            temp = Player.score;
            DataBaseDDOL.scoreDDOL = temp;
            this.gameObject.GetComponent<Text>().text = ("SCORE\n" + Player.score);
        }
    }
}

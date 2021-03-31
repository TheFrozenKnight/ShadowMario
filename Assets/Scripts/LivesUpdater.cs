using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUpdater : MonoBehaviour
{
    public static int temp = 3;
    void Start()
    {
        temp = DataBaseDDOL.livesDDOL;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.lives != temp)
        {
            temp = Player.score;
            DataBaseDDOL.livesDDOL = temp;
            this.gameObject.GetComponent<Text>().text = ("LIVES: " + Player.lives);
        }
    }
}

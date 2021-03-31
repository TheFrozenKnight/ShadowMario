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
        this.gameObject.GetComponent<Text>().text = ("LIVES" + DataBaseDDOL.livesDDOL);
    }

    void Update()
    {
        if (Player.lives != temp)
        {
            temp = Player.lives;
            DataBaseDDOL.livesDDOL = temp;
            this.gameObject.GetComponent<Text>().text = ("LIVES" + DataBaseDDOL.livesDDOL);
        }
    }
}

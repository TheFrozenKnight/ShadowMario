using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseDDOL : MonoBehaviour
{
    public static int livesDDOL;
    public static int scoreDDOL;
    public static int coinsDDol;
    public static DataBaseDDOL instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Player.coins = coinsDDol;
        Player.lives = livesDDOL;
    }
    /* Start is called before the first frame update
    void Start()
    {
        Player.coins = coinsDDol;
        Player.lives = livesDDOL;
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseDDOL : MonoBehaviour
{
    public static int livesDDOL;

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
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.lives = livesDDOL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

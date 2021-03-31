using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUpdater : MonoBehaviour
{
    public static int temp = 0;
    void Start()
    {
        temp = DataBaseDDOL.coinsDDol;
        this.gameObject.GetComponent<Text>().text = ("COINS" + DataBaseDDOL.coinsDDol);
    }

    void Update()
    {
        if (Player.coins != temp)
        {
            temp = Player.coins;
            DataBaseDDOL.coinsDDol = temp;
            this.gameObject.GetComponent<Text>().text = ("COINS" + DataBaseDDOL.coinsDDol);
        }
    }
}

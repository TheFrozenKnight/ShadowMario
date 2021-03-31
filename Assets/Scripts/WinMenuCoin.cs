using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuCoin : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = ("Coins: " + DataBaseDDOL.coinsDDol);
    }
}

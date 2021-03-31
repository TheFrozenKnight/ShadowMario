using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuScore : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = ("Score: " + DataBaseDDOL.scoreDDOL);
    }
}

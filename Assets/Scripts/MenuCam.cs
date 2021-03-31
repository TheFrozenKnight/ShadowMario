using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCam : MonoBehaviour
{
    public float camspeed = 1f;
    void Update()
    {
        transform.Translate(camspeed*Time.deltaTime,0f,0f);
    }
}

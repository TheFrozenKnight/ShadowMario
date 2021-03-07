using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    private void FixedUpdate()
    {
        float playerXPos = target.position.x;
        float cameraXPos = Mathf.Clamp(playerXPos, 0.00f, 100f);
        transform.position = new Vector3(cameraXPos, 0.00f, -10f);
    }
}
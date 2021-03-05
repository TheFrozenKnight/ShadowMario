using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Transform Plant;

    // Start is called before the first frame update
    void Start()
    {
        Plant = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

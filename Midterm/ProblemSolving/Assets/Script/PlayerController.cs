using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    public GameObject Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector3((float)Math.Cos(0), 0, (float)Math.Sin(0)));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector3((float)Math.Cos(90), 0, (float)Math.Sin(90)));
        }
        if (Input.GetKeyDown(KeyCode.S))//
        {
            transform.Translate(new Vector3(-(float)Math.Cos(0), 0, -(float)Math.Sin(0)));
        }
        if (Input.GetKeyDown(KeyCode.D))//
        {
            transform.Translate(new Vector3(-(float)Math.Cos(90), 0, -(float)Math.Sin(90)));
        }
    }
    
}

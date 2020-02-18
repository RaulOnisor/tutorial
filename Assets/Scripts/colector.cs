﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colector : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.up* Time.deltaTime * speed);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int speed = 5;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}

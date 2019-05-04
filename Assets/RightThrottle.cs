using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightThrottle : MonoBehaviour
{
    Boolean Rightmaxlock;
    Boolean Leftmaxlock;
    float rotatespeed = 22.55f;
    public float xangle;
    public int xiterations;
    Boolean pulldown;
    Boolean pullup;

    // Start is called before the first frame update
    void Start()
    {
        xiterations = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // xangle = transform.eulerAngles.x;
        if (Input.GetButton("C_Down") && Rightmaxlock == false)
        {
            transform.Rotate(rotatespeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
            Debug.Log(transform.rotation.x);
        }

        if (Input.GetButton("C_Up") && Leftmaxlock == false)
        {
            transform.Rotate(-rotatespeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        }

        xangle = transform.localEulerAngles.x;
        if (xangle > 260)
        {
            pulldown = true;
        }
        else
        {
            pulldown = false;
        }

        if (xangle > 0 && xangle < 250)
        {
            pullup = true;
        }
        else
        {
            pullup = false;
        }



        if (xangle <= 270.8f && xiterations > 1 && pulldown)
        {
            Leftmaxlock = true;
        }
        else
        {
            Leftmaxlock = false;
        }

        if (xangle >= 89.0f && xiterations > 1 && pullup)
        {
            Rightmaxlock = true;
        }
        else
        {
            Rightmaxlock = false;
        }
        xiterations++;
    }
}

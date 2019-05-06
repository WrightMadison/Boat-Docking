using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrans : MonoBehaviour
{
    private int frames = 0;
    public GameObject Cube;
    public float maxtransmissionangle = 90.0f;
    public float xangle;
    Boolean rightmaxlock;
    Boolean leftmaxlock;

    public Boolean upshifted;
    public Boolean downshifted;
    public Boolean neutral;

    // Start is called before the first frame update
    void Start()
    {
        rightmaxlock = false;
        neutral = true;
    }

    // Update is called once per frame
    // This sets up the transmission to move between -90 and 90 degrees
    void Update()
    {
        frames++;
        if(frames %5 !=0)
        {
            return;
        }
        xangle = Cube.transform.eulerAngles.x;
        if (Input.GetButton("C_Left") && rightmaxlock == false)
        {
            Cube.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            if(neutral==true)
            {
                downshifted = true;
                upshifted = false;
                neutral = false;
            }
            else
            {
                downshifted = false;
                upshifted = false;
                neutral = true;
            }
        }

        if (Input.GetButton("C_Right") && leftmaxlock == false)
        {
            Cube.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
            if(neutral==true)
            {
                downshifted = false;
                upshifted = true;
                neutral = false;
            }
            else
            {
                downshifted = false;
                upshifted = false;
                neutral = true;
            }
        }
        xangle = Cube.transform.localEulerAngles.x;
        if (xangle == 90.0f)
        {
            rightmaxlock = true;
        }
        else
        {
            rightmaxlock = false;
        }

        if (xangle == 270.0f)
        {
            leftmaxlock = true;
        }
        else
        {
            leftmaxlock = false;
        }
    }
}

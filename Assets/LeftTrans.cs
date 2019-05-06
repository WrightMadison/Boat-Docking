using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrans : MonoBehaviour
{
    private int frames = 0;
    public GameObject Cube;
    public float maxtransmissionangle = 90.0f;
    public float xangle;
    Boolean rightmaxlock;
    Boolean leftmaxlock;

    public Boolean Upshifted;
    public Boolean neutral;
    public Boolean downshifted;

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
        if(frames % 3!=0)
        {
            return;
        }
        xangle = Cube.transform.eulerAngles.x;
        if (Input.GetButton("D_Right") && rightmaxlock == false)
        {
            Cube.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
            if(neutral==true)
            {
                Upshifted = false;
                downshifted = true; ;
                neutral = false;
            }
            else
            {
                Upshifted = false;
                downshifted = false;
                neutral = true;
            }
            //  xangle += 90.0f;
        }

        if (Input.GetButton("D_Left") && leftmaxlock == false)
        {
            Cube.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
            if(neutral==true)
            {
                Upshifted = true;
                neutral = false;
                downshifted = false;
            }
            else
            {
                Upshifted = false;
                neutral = true;
                downshifted = false;
            }
            //xangle -= 90.0f;
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
        //xangle = Mathf.Clamp(xangle, -maxtransmissionangle, maxtransmissionangle);
        /*
        if(xangle==-180)
        {
            Cube.transform.localEulerAngles = new Vector3(90.0f, Cube.transform.localEulerAngles.y, Cube.transform.localEulerAngles.z);
        }
        if (xangle == -270)
        {
            Cube.transform.localEulerAngles = new Vector3(xangle, Cube.transform.localEulerAngles.y, Cube.transform.localEulerAngles.z);
        }
        */
        //Debug.Log("Upshifted is "+Upshifted);
        //Debug.Log("Neutral is "+ neutral);
        //.Log("downshifted is "+downshifted);
    }
}

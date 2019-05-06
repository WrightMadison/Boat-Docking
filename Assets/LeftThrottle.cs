using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftThrottle : MonoBehaviour
{
    Boolean Rightmaxlock;
    Boolean Leftmaxlock;
    float rotatespeed = 50f;
    public float xangle;
    public int xiterations;
    Boolean pulldown;
    Boolean pullup;
    GameObject lefttrans;
    LeftTrans pscript;

    // Start is called before the first frame update
    void Start()
    {
        lefttrans = GameObject.Find("LeftTransmission");
         pscript = lefttrans.GetComponent<LeftTrans>();
        xiterations = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // xangle = transform.eulerAngles.x;
        if (Input.GetButton("D_Down") && Rightmaxlock == false)
        {
            transform.Rotate(rotatespeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        }

        if (Input.GetButton("D_Up") && Leftmaxlock == false)
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



        if (xangle <= 273.8f && xiterations > 1 && pulldown)
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
        Debug.Log("LeftTrans neutral is" + pscript.neutral);
        
    }
}

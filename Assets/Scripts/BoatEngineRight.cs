﻿using UnityEngine;
using System.Collections;

public class BoatEngineRight : MonoBehaviour
{
    //Drags
    public Transform waterJetTransform;

    //How fast should the engine accelerate?
    public float powerFactor;

    //What's the boat's maximum engine power?
    public float maxPower;

    //The boat's current engine power is public for debugging
    public float currentJetPower;

    private float thrustFromWaterJet = 0f;

    private Rigidbody boatRB;

    private float WaterJetRotation_Y = 0f;

    BoatController boatController;

    public Transform cubeTransform; //This is the transform of the engine.

    public Transform rotorTransform;

    //this is for transmission states
    GameObject righttrans;
    RightTrans pscript;

    void Start()
    {
        boatRB = GetComponent<Rigidbody>();
        righttrans = GameObject.Find("RightTransmission");
        pscript = righttrans.GetComponent<RightTrans>();
        boatController = GetComponent<BoatController>();
    }


    void Update()
    {
        UserInput();
    }

    void FixedUpdate()
    {
       UpdateWaterJet();
        Vector3 tempForward = new Vector3(cubeTransform.forward.x, cubeTransform.forward.y, cubeTransform.forward.z);

        if (pscript.upshifted && currentJetPower > 0)
        {
            boatRB.AddForceAtPosition(Quaternion.Euler(0, -90, 0) * tempForward * -currentJetPower, rotorTransform.position, ForceMode.Force);
        }
        else if (pscript.neutral)
        {

        }
        else if (pscript.downshifted && currentJetPower < 0)
        {
            boatRB.AddForceAtPosition(Quaternion.Euler(0, -90, 0) * tempForward * -currentJetPower, rotorTransform.position, ForceMode.Force);
        }
    }

    void UserInput()
    {

        //Forward
        if (Input.GetButton("C_Up"))
        {
            if (currentJetPower <= maxPower)
            {
                currentJetPower += 1f * powerFactor;
            }
        }
        else if (Input.GetButton("C_Down")) //Reverse
        {
            if (-maxPower < currentJetPower)
            {
                currentJetPower -= 1f * powerFactor;
            }
        }    

        //Steer left
        if (Input.GetButton("Left"))
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + 1f;
            //Debug.Log("angles " + WaterJetRotation_Y);
            //waterJetTransform.loca
            if (WaterJetRotation_Y > 105f)
            {
                WaterJetRotation_Y = 105f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

            waterJetTransform.localEulerAngles = newRotation;
        }
        //Steer right
        else if (Input.GetButton("Right"))
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - 1f;

            if (WaterJetRotation_Y < 75f)
            {
                WaterJetRotation_Y = 75f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

            waterJetTransform.localEulerAngles = newRotation;
        }

        //Steer left with joysticks
        if (Input.GetAxis("Horizontal") < 0)
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + 1f;
            Debug.Log("angles " + WaterJetRotation_Y);
            //waterJetTransform.loca
            if (WaterJetRotation_Y > 105f)
            {
                WaterJetRotation_Y = 105f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

            waterJetTransform.localEulerAngles = newRotation;
        }

        //Steer right with joysticks
        else if (Input.GetAxis("Horizontal") > 0)
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - 1f;

            if (WaterJetRotation_Y < 75f)
            {
                WaterJetRotation_Y = 75f;
            }

            Vector3 newRotation = new Vector3(0f, WaterJetRotation_Y, 0f);

            waterJetTransform.localEulerAngles = newRotation;
        }

    }


    void UpdateWaterJet()
    {
        //Debug.Log(boatController.CurrentSpeed);

        Vector3 forceToAdd = -waterJetTransform.forward * currentJetPower;

        //Only add the force if the engine is below sea level
        float waveYPos = WaterController.current.GetWaveYPos(waterJetTransform.position, Time.time);

        if (waterJetTransform.position.y < waveYPos)
        {
            boatRB.AddForceAtPosition(forceToAdd, waterJetTransform.position);
        }
        else
        {
            boatRB.AddForceAtPosition(Vector3.zero, waterJetTransform.position);
        }
    }
}
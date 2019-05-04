using UnityEngine;
using System.Collections;

public class BoatEngine : MonoBehaviour
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

    void Start()
    {
        boatRB = GetComponent<Rigidbody>();

        boatController = GetComponent<BoatController>();
    }


    void Update()
    {
        UserInput();
    }

    void FixedUpdate()
    {
        UpdateWaterJet();
    }

    void UserInput()
    {
        string[] joysticks = Input.GetJoystickNames();
        for (int i = 0; i < joysticks.Length; i++) {
            Debug.Log("joystick " + joysticks[i]);
        }

        Debug.Log("vert" + Input.GetAxis("Joy_Vertical"));
        Debug.Log("hor" + Input.GetAxis("Horizontal"));

        //Forward
        if (Input.GetButton("C_Up"))
        {
            if (boatController.CurrentSpeed < 50f && currentJetPower < maxPower)
            {
                currentJetPower += 1f * powerFactor;
                Debug.Log("forward is " + cubeTransform.forward);
                //forward vector points out of left of rotor
                Vector3 tempForward = new Vector3(cubeTransform.forward.x, cubeTransform.forward.y, cubeTransform.forward.z);
                boatRB.AddForceAtPosition(Quaternion.Euler(0, -90, 0) * tempForward * -currentJetPower, rotorTransform.position, ForceMode.Force);
            }
        }
        else if (Input.GetButton("C_Down")) //Reverse
        {
            if (boatController.CurrentSpeed < 50f && currentJetPower < maxPower)
            {
                currentJetPower -= 1f * powerFactor;
                Vector3 tempForward = new Vector3(cubeTransform.forward.x, cubeTransform.forward.y, cubeTransform.forward.z);
                boatRB.AddForceAtPosition(Quaternion.Euler(0, -90, 0) * tempForward * -currentJetPower, rotorTransform.position, ForceMode.Force);
            }
        } else
        {
            currentJetPower = 0f;
        }        

        //Steer left
        if (Input.GetButton("Left"))
        {
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y + 2f;
            Debug.Log("angles " + WaterJetRotation_Y);
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
            WaterJetRotation_Y = waterJetTransform.localEulerAngles.y - 2f;

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
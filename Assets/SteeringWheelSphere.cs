using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteeringWheelSphere : MonoBehaviour
{
    public Image SteeringWheel;


    // Update is called once per frame
    void Update()
    {
        Vector3 wheelpos = Camera.main.WorldToScreenPoint(this.transform.position);
        SteeringWheel.transform.position = wheelpos;


    }
}

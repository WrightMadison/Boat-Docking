using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 rotateValue;
    private float rotationValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetButton("LB"))
        {
            rotationValue -= 5f;

            // Rotate the camera by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(10f, rotationValue, transform.rotation.z);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1f);
        }

        if (Input.GetButton("RB"))
        {
            rotationValue += 5f;

            // Rotate the camera by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(10f, rotationValue, transform.rotation.z);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, 1f);
        }

    }
}

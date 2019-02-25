using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    private Vector3 rotateValue;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -50 * Time.deltaTime);
            offset = transform.position - player.transform.position;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 50 * Time.deltaTime);
            offset = transform.position - player.transform.position;
        }
    }
}

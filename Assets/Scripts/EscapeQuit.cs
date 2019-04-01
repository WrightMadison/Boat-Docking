using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeQuit : MonoBehaviour
{
    public void Update() {
    if (Input.GetKeyUp(KeyCode.Escape)) {
        Application.Quit();
    }
}
}

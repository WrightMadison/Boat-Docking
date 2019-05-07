using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeQuit : MonoBehaviour
{
	//this script ensures that when the Escape key is hit
	//that the application closes. 
	
    public void Update() {
    if (Input.GetKeyUp(KeyCode.Escape)) {
        Application.Quit();
    }
}
}

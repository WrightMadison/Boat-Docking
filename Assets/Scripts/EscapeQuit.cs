using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeQuit : MonoBehaviour
{
	//this script ensures that when the Escape key is hit
	//that the load level screen appears.  
	
    public void Update() {
    if (Input.GetKeyUp(KeyCode.Escape)) {
        SceneManager.LoadScene(1);
    }
}
}

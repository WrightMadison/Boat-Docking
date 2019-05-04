using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
	public void changeMenuScene(string scenename){
		Application.LoadLevel(scenename);
	}
}

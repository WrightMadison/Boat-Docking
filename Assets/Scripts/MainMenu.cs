using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	//this script allows the main menu of the game to function, 
	//and each "button" to lead to it's respected level depending
	//on what the button is set to in the inspector when clicked. 
	
	public bool isStart;
	public bool isQuit;
	public bool level1;
	public bool level2;
	public bool level3;
	public bool isBack;

	//the selection only activates when, after being pressed down for the 
	//click, the mouse button is let back up
	void OnMouseUp(){

	//the start button on the title screen - opens the level select scene
	if(isStart){	SceneManager.LoadScene(1);	}
	
	//the quit button on the title screen, closes the game. Only 
	//works in the actual build. 
	if (isQuit){	Application.Quit();	}
	
	//Level 1 option on the level selection screen
	if(level1){		SceneManager.LoadScene(2);	}
	
	//Level 2 option on the level selection screen. 
	//Currently inactive
	if(level2){		SceneManager.LoadScene(3);	}
	
	//Level 3 option on the level selection screen.
	//Currently inactive. 
	if(level3){		SceneManager.LoadScene(4);	}
	
	//The back button on the level selection screen
	//takes the user back to the title screen
	if(isBack){		SceneManager.LoadScene(0);	}
} 
	
}

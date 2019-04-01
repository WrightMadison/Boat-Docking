using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	public bool isStart;
	public bool isQuit;
	public bool level1;
	public bool level2;
	public bool level3;
	public bool isBack;

	void OnMouseUp(){
	if(isStart)
	{
		SceneManager.LoadScene(1);
	}
	if (isQuit)
	{
		Application.Quit();
	}
	if(level1)
	{
		SceneManager.LoadScene(2);
	}
	if(level2)
	{
		SceneManager.LoadScene(3);
	}
	if(level3)
	{
		SceneManager.LoadScene(4);
	}
	if(isBack)
	{
		SceneManager.LoadScene(0);
	}
} 
	
}

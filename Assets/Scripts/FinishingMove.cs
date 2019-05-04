using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingMove : MonoBehaviour
{
	public bool finishChecker;
	public GameObject winUI;
	public GameObject scoreboard;
	public GameObject wheel;
	public GameObject final;

	//public Rect windowRect = new Rect(20,20,120,50);
 

	void Start(){
		winUI = GameObject.Find("WinUI");
		winUI.SetActive(false);
		finishChecker = false;
		scoreboard = GameObject.Find("Scoreboard");
		wheel = GameObject.Find("SteeringWheel");


	}
	
	void OnTriggerStay(Collider other)
    {
		if(finishChecker == true){
		//Debug.Log("Magnitude On Trigger Stay: " + other.attachedRigidbody.velocity.magnitude);
			if (other.attachedRigidbody.velocity.magnitude < 0.05){
			winUI.SetActive(true);
			final = GameObject.Find("FinalScore");
			final.GetComponent<Text>().text = "Final " + scoreboard.GetComponent<BoatCollider>().score.text;//+ scoreboard.GetComponent<BoatCollider>().scoreValue;
			Debug.Log(scoreboard.GetComponent<BoatCollider>().score.text);
			
			final.SetActive(false);
			final.SetActive(true);
			
			scoreboard.SetActive(false);
			
			wheel.SetActive(false);
			//GameObject.Find("Canvas").ForceUpdateCanvases();
			//final.SetActive(false);
			//final.SetActive(true);
			

			}
		}
	}
	


}

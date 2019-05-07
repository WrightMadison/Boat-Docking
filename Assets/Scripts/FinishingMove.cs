using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishingMove : MonoBehaviour
{
	//this script is the last step in detecting and activating the final 
	//parking procedures. It collaborates via the finishChecker variable
	//to determine that A) the boat is in the right spot, B) That the 
	//boat is slowed down enough to roughly equate being "parked", and
	//that the player has decided they are done, and C) actually send out
	//the popups giving the player their final results, and allowing them 
	//to return to the menus, or exit the game. 
	
	public bool finishChecker;
	public GameObject winUI;
	public GameObject scoreboard;
	public GameObject wheel;
	public GameObject final;

	void Start(){
		//Locate the WinUI item - it has to be on originally for the game
		//to acccess it later, but we turn it off as soon as the game starts so that 
		//the player doesn't see it untill the end
		winUI = GameObject.Find("WinUI");
		winUI.SetActive(false);
		
		//asserting that finishChecker is turned off - this variable
		//is set to true in the FinishCheck script when the boat is 
		//colliding with the invisible FinishDist object to ensure that 
		//the boat is parked close enough into the dock. 
		finishChecker = false;
		
		//locate the Scoreboard and the wheel so that we can turn them off appropriately later
		scoreboard = GameObject.Find("Scoreboard");
		wheel = GameObject.Find("SteeringWheel");
	}

	void OnTriggerStay(Collider other)
    {
		//finishChecker is a variable influenced in FinishCheck script
		//as mentioned above
		if(finishChecker == true){
			
			//if the boat has actually slowed down enough to be "parked", or rather, an approximation of still
			if (other.attachedRigidbody.velocity.magnitude < 0.05){
				
			//activating the UI elements that show the final info popup
			winUI.SetActive(true);
			
			
			//finding the item for the final score, and updating it to match the scoreboard
			final = GameObject.Find("FinalScore");			
			final.GetComponent<Text>().text = "Final " + scoreboard.GetComponent<BoatCollider>().score.text;
			
			//flicker the final displayed score off and on to make sure its updated
			final.SetActive(false);
			final.SetActive(true);
			
			//turn off the old scoreboard and the steering wheel
			scoreboard.SetActive(false);
			wheel.SetActive(false);

			}
		}
	}
	


}

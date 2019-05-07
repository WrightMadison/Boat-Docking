using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
	//this script works with the FinishingMove script to ensure that the 
	//boat is parked far enough in toward the dock. It works on the invisible 
	//FinishDist item to turn FinishingMove's finishChecker variable
	//to true or false depending on whether the boat is currently
	//within the FinishDist item. 
	
	public GameObject finishingmoveItem;
	
	//if the boat enters the FinishDist item, the finishChecker is set to true
	void OnTriggerStay(Collider other)
    {
		finishingmoveItem.GetComponent<FinishingMove>().finishChecker = true;
	}
	
	//if the boat leaves the FinishDist item, the finishChecker is set to false. 
	void OnTriggerExit(Collider other)
    {
		finishingmoveItem.GetComponent<FinishingMove>().finishChecker = false;
	}
}

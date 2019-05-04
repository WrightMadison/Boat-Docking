using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{
	
	public GameObject finishingmoveItem;
	
	
    // Start is called before the first frame update
	
	void OnTriggerStay(Collider other)
    {
		finishingmoveItem.GetComponent<FinishingMove>().finishChecker = true;
		
	}
	
	void OnTriggerExit(Collider other)
    {
		finishingmoveItem.GetComponent<FinishingMove>().finishChecker = false;
		
	}
	
	
	
//void OnCollisionEnter (Collision col)
//    {
//		if (col.gameObject.name == "boat"){
//			finishingmoveItem.GetComponent<FinishingMove>().finishChecker = true;
//			//FinishingMove.finishChecker = true;
//		}
//		
//	}
}

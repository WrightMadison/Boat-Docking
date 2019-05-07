using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CollisionDetector : MonoBehaviour{
	//this script calculates the value that is given to 
	//the scoreboard as percieved financial damage to the 
	//boat when it runs into any non-trigger item aside from
	//the Seawall game object, an invisible wall that keeps the 
	//player in bounds.

	//when a collision is detected
	void OnCollisionEnter (Collision col){

		//checking that the object is not the no-damage Seawall
        if(col.gameObject.name != "Seawall"){
			
			//varying magnitudes of collision lead to various amounts of 
			//"damage" added to the scoreboard stored in the BoatCollider
			//script. Go crazy with the numbers and equations till you find something 
			//you like. Pick your poison. It's currently a random number
			//from a set range based on magnitude generally multiplied by that magnitude.
			if(col.relativeVelocity.magnitude >= 0){//least damage. 
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(100,1000));
			}else if (col.relativeVelocity.magnitude >= 1){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(1000,2000)* (int)col.relativeVelocity.magnitude);
			}else if (col.relativeVelocity.magnitude >= 5){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(2000,10000)* (int)col.relativeVelocity.magnitude);
			}else if(col.relativeVelocity.magnitude < 5){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(10000,20000)* (int)col.relativeVelocity.magnitude);
			}else{//maximum damage
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(20000,50000)* (int)col.relativeVelocity.magnitude);
			}

        }
    }
}

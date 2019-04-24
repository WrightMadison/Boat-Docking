using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random;

public class CollisionDetector : MonoBehaviour{
    // Start is called before the first frame update
void OnCollisionEnter (Collision col){

	//t = canvas.GetComponent<Text>();
			Debug.Log(col.gameObject.name);
        if(col.gameObject.name != "Seawall"){
			
			if(col.relativeVelocity.magnitude >= 1){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(10,50)* (int)col.relativeVelocity.magnitude);
			}else if (col.relativeVelocity.magnitude >= 5){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(50,100)* (int)col.relativeVelocity.magnitude);
			}else if(col.relativeVelocity.magnitude < 5){
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(100,200)* (int)col.relativeVelocity.magnitude);
			}else{
				BoatCollider.scoreValue = BoatCollider.scoreValue + ((int)Random.Range(200,500)* (int)col.relativeVelocity.magnitude);
			}
				
			//BoatCollider.scoreValue = BoatCollider.scoreValue + (10* (int)col.relativeVelocity.magnitude);
			//t.text = "Score: " + score;
			//Destroy(col.gameObject);

        }
    }
}

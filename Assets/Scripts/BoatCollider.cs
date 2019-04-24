using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatCollider : MonoBehaviour
{

//	Text t;
	public static int scoreValue = 0;
	Text score;
	
	void Start(){
		score = GetComponent<Text>();
	}
	void Update(){
		score.text = "Damage: $" + scoreValue;
	}
	
	void OnCollisionEnter (Collision col)
    {

	//t = canvas.GetComponent<Text>();
			Debug.Log(col.gameObject.name);
        if(col.gameObject.name != "Seawall")
        {
			BoatCollider.scoreValue++;
			//t.text = "Score: " + score;
			//Destroy(col.gameObject);

        }
    }

}

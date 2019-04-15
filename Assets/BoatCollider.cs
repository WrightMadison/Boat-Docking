using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollider : MonoBehaviour
{
	public float duration; //set the duration in the inspector
    float elapsedTime = Mathf.Infinity;
	
	//Object oof;
	
	void OnCollisionEnter (Collision col)
    {
		//Debug.Log("Testing");
		Debug.Log(col.gameObject.name);
        if(col.gameObject.name != "Seawall")
        {
			Destroy(col.gameObject);
		//	oof.color.a = 1f;
			elapsedTime = 0f;
			Debug.Log("0 seconds");
			if (elapsedTime < duration) {
			    Debug.Log("5 seconds");
		//	    oof.color.a = 0f;
	
			}
        }
    }

	
}

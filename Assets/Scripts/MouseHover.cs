using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
	//this script modifies the color of the options
	//being hovered over on the title and level select screens
	//whenever the mouse enters or exits their box colliders. 

{
   void Start(){
	GetComponent<Renderer>().material.color = Color.blue;
}

void OnMouseEnter(){
	GetComponent<Renderer>().material.color = Color.black;
}

void OnMouseExit() {
	GetComponent<Renderer>().material.color = Color.blue;
}
}

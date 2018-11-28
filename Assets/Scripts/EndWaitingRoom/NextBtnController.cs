/**
 * script for next button in end waiting room
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBtnController : MonoBehaviour {
	
	public EndPandaController pandaScript;
	public GameObject speechBubble;

	void OnMouseDown(){
		pandaScript.finalWalk (); // panda walk off
		Destroy(speechBubble.gameObject);
	}
}

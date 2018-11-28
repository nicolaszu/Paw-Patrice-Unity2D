using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when scanning bed is clicked on, the panda walks

public class ScanTrigger : MonoBehaviour {

	public ScanPanda scanScript;

	void OnMouseDown(){

		scanScript.canWalkOn (); //Activate this method when it has been clicked on

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This script is responsible for the reoccuring background scene
*/

public class ReoccuringBackground : MonoBehaviour {

	public double speed;
	// Update is called once per frame
	void Update () {
		double posX = transform.position.x;
		double updatedPos = posX - (speed/10);
		if (updatedPos <= -23.5) {
			updatedPos = 47; 
		}
		transform.position = new Vector2((float) updatedPos, transform.position.y);
	}
}

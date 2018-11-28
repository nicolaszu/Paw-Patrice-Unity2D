using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 This script is responsible for the movement of the food across the lanes displayed in the scene.
*/

public class FoodMovementScript : MonoBehaviour {

	public double speed;
	// Update is called once per frame
	void Update () {
		double posX = transform.position.x;
		double updatedPos = posX - (speed/10);
		transform.position = new Vector2((float) updatedPos, transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("FoodEndpoint"))
		{
			double newYPos = 0;
			float rInteger = Random.value;
			if (rInteger > 0.66) {
				newYPos = -0.6;
			} else if (rInteger > 0.33) {
				newYPos = -2.8;
			} else {
				newYPos = -4.9;
			}
			transform.position = new Vector2(66, (float) newYPos);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y,0);
				
		}
	}
}

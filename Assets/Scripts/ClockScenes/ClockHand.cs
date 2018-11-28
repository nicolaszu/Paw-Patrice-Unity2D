using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHand : MonoBehaviour {
	//the angle around the correct angle to snap the hand to
	public float snapAngle;
	//the correct angle for the hand to be at
	public float correctPos;

	//boolean storing whether the hand is in the correct position
	public bool isCorrect = false;

	//boolean storing whether the hand can move
	public bool canMove = false;

	//internal variables for tracking mouse movement
	private Vector2 mousePos;
	private Vector2 screenPos;

	private float uBound;
	private float lBound;

	void Start () {
		uBound = correctPos + snapAngle;
		//Debug.Log (correctPos + " + " + snapAngle + " = " + correctPos);
		lBound = correctPos - snapAngle;

		if (lBound < 0)
			lBound += 360;
	}

	// Update is called once per frame
	void Update () {
		if (canMove) {
			//find the position of the mouse, and the relative position of the mouse on the screen
			mousePos = Input.mousePosition;
			screenPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

			//find the related angle from the hand to the mouse
			transform.rotation = Quaternion.Euler (0, 0, Mathf.Atan2 ((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg - 90);
		}

		//if the angle of the hand is within the snap range, snap to the correct angle, and return the position is correct
		if (checkPos()) {
			transform.rotation = Quaternion.Euler (0, 0, correctPos);
			isCorrect = true;
		} else {
			isCorrect = false;
		}
	}

	bool checkPos() {
		float targetRot = transform.eulerAngles.z;

		//Debug.Log ("Angle: " + targetRot + " | uBound: " + uBound + " | lBound: " + lBound);

		if (lBound > uBound) {
			if (targetRot > lBound)
				return true;

			if (targetRot < uBound)
				return true;
		}

		if (targetRot > lBound && targetRot < uBound)
			return true;

		return false;
	}
}
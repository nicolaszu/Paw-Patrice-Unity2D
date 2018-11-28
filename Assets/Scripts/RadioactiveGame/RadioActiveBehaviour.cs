using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that describes the behaviour of the falling objects
public class RadioActiveBehaviour : MonoBehaviour {

	// Update is called once per frame, this destroys all falling objects when they reach y = -10, so program does not overflow
	// with cloned objects
	void Update () {
		if (transform.position.y <= -10) Destroy (gameObject);
	}
}
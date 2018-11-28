using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

//control movement of right sliding door

public class SlidingRightDoor : MonoBehaviour {

	private Vector2 aPosition1;

	// Use this for initialization
	void Start () {

		aPosition1 = new Vector2 ((float) 0.65, (float) -1.16); //control movement of right door
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
			aPosition1, 3 * Time.deltaTime);
		//testPosition ();
		
	}

	//test function

	void testPosition(){

		Assert.IsTrue (aPosition1.x <= 0.65);
		Assert.IsTrue (aPosition1.y >= -1.16);

	}
}

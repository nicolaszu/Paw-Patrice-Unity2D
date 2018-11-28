/**
 *  this script moves the plant on click 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlantController : MonoBehaviour {

	public float speed;

	public void Start(){

		testComp2DBoxCol();
		testCompRigidBody ();
	}

	/**
	 * slide right on click 
	 */
	void OnMouseDown(){
		slideRight ();
		testPosition ();
	}
	/*
	 * mehtod to slide plant to right
	 */
	void slideRight(){
		if (transform.localPosition.x < 7.5f) { // to stop plant going off screen

			Vector3 newPos = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z); 
			transform.position = Vector3.MoveTowards (transform.position, newPos, speed * Time.deltaTime); // move to new pos 
		}

	}
	/*
	 * testing funcs 
	 */

	void testPosition () {
		Assert.IsTrue (!(transform.localPosition.y > 7.5f));
	}
	void testCompRigidBody(){
		Assert.IsNotNull (transform.GetComponent<Rigidbody2D> ());
	}
	void testComp2DBoxCol(){
		Assert.IsNotNull (transform.GetComponent<BoxCollider2D> ());
	}
}

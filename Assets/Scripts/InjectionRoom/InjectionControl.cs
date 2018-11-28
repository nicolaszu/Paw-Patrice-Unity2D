using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script is in charge of the animation for the injection character
 */

public class InjectionControl : MonoBehaviour {
	
	public Animator anim; //injection character animator

	private float xPos=0.6f;

	private  GameObject timerKeeper;
	private Timer timer;


	// Use this for initialization
	void Start () {
		timerKeeper = GameObject.Find ("Canvas/Timer").gameObject;
		timer = timerKeeper.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update() {


		//If game isnt over, follow the cursor location
		if (timer.getTime ()>0.5) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 mousePosNeed = new Vector3 (mousePos.x + xPos, mousePos.y + 1, mousePos.z);
			mousePosNeed.z = 5f;
			transform.position = mousePosNeed; //injection character location=mouse location

			if (Input.GetMouseButtonUp (0)) { //if mouse is clicked, animations are triggered
				anim.SetTrigger ("Inject");
				anim.SetTrigger ("refill");
			}
		} 

		//If game is over, freeze location
		else if(timer.getTime () <= 0.5)
			transform.position = transform.position;
	}

}

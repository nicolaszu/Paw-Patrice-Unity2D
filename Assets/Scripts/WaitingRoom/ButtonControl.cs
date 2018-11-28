/**
 * This script controls the red button for sky animaiton.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ButtonControl : MonoBehaviour {
	private SpriteRenderer sr;
	private SpriteRenderer sunSR;
	public Sprite pressed;
	public Sprite normal;
	public Sprite moon;
	public Sprite sun;
	public GameObject sunObj;
	public GameObject Sky;	
	public AudioSource button;
	public AudioSource day;
	public AudioSource night;

	private int click = 0; 
	private float fadeSpeed = 0.5f;
	private Animator anim;


	// Use this for initializa	tion
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		sunSR = sunObj.GetComponent<SpriteRenderer> ();
		anim = sunObj.GetComponent<Animator> ();
//		testCompSpriteRend ();
	}
	
	// Update is called once per frame
	void Update () {
		var material = Sky.GetComponent<Renderer>().material;
		var color = material.color;

		if (click == 2) { // fade sky to transparent to show night sky
			if(color.a>=0)
				material.color = new Color(color.r, color.g, color.b, color.a - (fadeSpeed * Time.deltaTime));

		}

		if (click == 0) { // bring back day sky 
			if(color.a<=1)
				material.color = new Color(color.r, color.g, color.b, color.a+ (fadeSpeed * Time.deltaTime) );
		}
	}

	void OnMouseDown(){
		sr.sprite = pressed; // button down 
		button.Play();
		switch (click) {

		case 0: // sun rise 
			if(anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Down")){
				sunSR.sprite = sun; // set image to sun
				riseAnim(); // call set animation method
				day.Play();
				++click;
			}
			break;
		case 1: // sun set 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Up")) {
				setAnim ();
				day.Stop();
				++click;
			}
			break;
		
		case 2: // moon rise 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Down")) {
				sunSR.sprite = moon; // set image to moon 
				riseAnim (); // call rise animation method 
				night.Play();
				++click;
			}
			break;
		
		case 3: // moon set 
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Idle_Up")) {
				setAnim ();
				night.Stop();
				click = 0;
			}
			break;
		}
	}
	/*
	 * sets sprite back when mb is released 
	 */
	void OnMouseUp(){
		sr.sprite = normal; //button up
	}
	/**
	 * method to trigger rise animation 
	 */
	void setAnim(){
		anim.SetTrigger ("Set");
		anim.SetBool ("Up", false);
		anim.SetBool ("Down", true);
	}
	/**
	 * mehtod to trigger set animation
	 */
	void riseAnim(){
		anim.SetTrigger ("Rise");
		anim.SetBool ("Up", true);
		anim.SetBool ("Down", false);

	}

	/**
	 * test funcs
	 */

	void testCompSpriteRend(){
		Assert.IsNotNull (transform.GetComponent<SpriteRenderer> ());
	}

}

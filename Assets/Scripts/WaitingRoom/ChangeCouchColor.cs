/**
 * this script changes sofa colour on click
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ChangeCouchColor : MonoBehaviour {

	public Sprite couchcolor1; 
	public Sprite couchcolor2; 
	public Sprite couchcolor3; 
	public Sprite couchcolor4; 
	public GameObject couch;
	SpriteRenderer spriteRenderer;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		source.time = 0.8f;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
//		testCompSpriteRend ();
//		testCompBoxCol();
	}
		
	//On Mouse click change color of couch...simply changes the sprite depending on previous sprite
	void OnMouseDown(){
		source.Play ();
		if (spriteRenderer.sprite == couchcolor1)
			spriteRenderer.sprite = couchcolor2;
			
		else if (spriteRenderer.sprite == couchcolor2)
			spriteRenderer.sprite = couchcolor3;
			
		else if (spriteRenderer.sprite == couchcolor3)
			spriteRenderer.sprite = couchcolor4;
			
		else if (spriteRenderer.sprite == couchcolor4)
			spriteRenderer.sprite = couchcolor1;

	}
	//testing func
	void testCompSpriteRend(){
		Assert.IsNotNull (transform.GetComponent<SpriteRenderer> ());
	}
	void testCompBoxCol(){
		Assert.IsNotNull (transform.GetComponent<BoxCollider2D> ());
	}
}
	

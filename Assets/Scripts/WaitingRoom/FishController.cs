/**
 * controls the fish in fish tank. responds to user click.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FishController : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;
	public GameObject fish;
	public GameObject bubblesPreFab;
	public float swimSpeed=1;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource>();
//		testCompRigidBody ();
//		testCompBoxCol ();

	}
	
	// fish swimming
	void Update () {

		rb.AddForce(Vector2.right * swimSpeed); //Fish swimming
		anim.SetFloat("Speed", swimSpeed);


	}

	//fish jump and bubble creation
	void OnMouseDown(){
		if(rb.position.y<1){
			rb.gravityScale = -3;//On click set grafity to negative so that the fish can float
			bubblesPreFab.transform.position= new Vector3(fish.transform.localPosition.x, transform.localPosition.y+0.85f, transform.localPosition.z);//set location of soon to be bubble to location above fish
			anim.SetBool("Jumping",true);
			if (swimSpeed < 0)
				anim.SetTrigger("Left Jump");
			else
				anim.SetTrigger("Right Jump");
			anim.SetBool ("Jumping", true);
			Instantiate(bubblesPreFab);//create bubble
			source.Play();
		}
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		//If collsion with collider above fish tank, then set grafity to positive so that fish falls
		if (coll.transform.gameObject.name=="FishTopCollider") {
			rb.gravityScale = 3;
			anim.SetBool ("Jumping", false); // stop jump
		
		} 

		//If collision with collider on fish tank floor level, then set gravity to zero so fish will simply swim 
		else if (coll.transform.gameObject.name=="FishBottomCollider") {
			rb.gravityScale = 0;

		} 

		//If collision with sides of tank, flip sprite and negate swim speed so fish will swim the oppsite way
		else {
			swimSpeed = -swimSpeed;


		}
	}
	/*
	 * testing funcs 
	 */

	void testCompRigidBody(){
		Assert.IsNotNull (transform.GetComponent<Rigidbody2D> ());
	}
	void testCompBoxCol(){
		Assert.IsNotNull (transform.GetComponent<BoxCollider2D> ());
	}
}

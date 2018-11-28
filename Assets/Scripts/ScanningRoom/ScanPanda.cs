using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

//control movement of panda, including walking towards and climbing on the bed

public class ScanPanda : MonoBehaviour {

	public float speed;
	public GameObject face;
	private bool canClimb;
	public GameObject background;
	float timeLeftforTransition=2;
	float timeLeftHitTrigger=2;
	private bool readyForTransition;
	private AudioSource source;

	bool canWalk;
	Animator anim;
	Rigidbody2D rb;

	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		canClimb = false;
		canWalk = false;
	
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;

		source = GetComponent<AudioSource>();

	}

	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		
		anim.SetFloat("Speed", rb.velocity.x);

		if (canWalk) {

			//testCanWalk ();
			rb.velocity = Vector2.left * speed;
			face.GetComponent<Animator>().SetBool("Walking", true); //if true, walk to the left 
			//testWalkingAnimationBool ();
		}

		if (canClimb){
			
			//testCanClimb ();
			rb.velocity = new Vector2(0, 0);
			anim.SetBool("IsClimbing", true); //when it approaches the collider climbing animation is activated
			//testClimbAnimationBool();
			face.GetComponent<Animator>().SetBool("Walking", true);
			//testWalkingAnimationBool ();
			timeLeftHitTrigger -= Time.deltaTime; //timer counts down leading to fade out

		}

		if (timeLeftHitTrigger <= 0) {

			readyForTransition = true; //start fade out when the timer hits 0

		}

		if (readyForTransition) {

			//testTransitionReady();
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}

		if (timeLeftforTransition <= 0) {
			
			SceneManager.LoadScene ("BeltScene"); //load belt scene once it has climbed onto the bed

		}

	}

	void OnTriggerEnter2D(Collider2D col){

		canClimb = true; //once it enters box collider, start climbing animation
		source.Play ();

	}

	public void canWalkOn(){

		canWalk = true; 

	}
		
	//test functions

	void testCanWalk(){

		Assert.IsTrue (canWalk);

	}

	void testCanClimb(){

		Assert.IsTrue (canClimb);

	}

	void testTransitionReady(){

		Assert.IsTrue (readyForTransition);

	}

	void testClimbAnimationBool(){

		Assert.AreEqual (true, anim.GetBool("IsClimbing"));

	}

	void testWalkingAnimationBool(){

		Assert.AreEqual (true, face.GetComponent<Animator>().GetBool("Walking"));

	}

}
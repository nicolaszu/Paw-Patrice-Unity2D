/**
 * end waiting room controller for panda
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Assertions;

public class EndPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject speechBub;
	//public GameObject text;

	bool walkOne;
	bool finalMove;
	bool middle;
	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		walkOne = true;
//		testCompRigidBody ();
//		testCompBoxCol();
	}

	void Update(){
//		testPosition ();
		anim.SetFloat("Speed", rb.velocity.x);
		if (walkOne) { // initial walk 
			//Debug.Log ("Inital walk");
			walk ();
		}
		if (middle) {
			//Debug.Log ("Show speech bubble");
			happyFace ();
			speechBub.SetActive (true);
//			testGameObjectIsActive (speechBub);
		}
		if (transform.position.x >= 0) { // stop walk at centre 
			walkOne = false;
			middle = true;
			awakeFace ();
			rb.velocity = new Vector2(0,0);
			anim.SetBool ("IsWaving", true); // start waving 
		}
		if (finalMove) { // final walk off scene
			//Debug.Log ("final Walk");
			middle = false;
			anim.SetBool ("IsWaving", false); // end waving 
			walk ();
		}
		if (transform.position.x >= 10.5) { // kill panda off scene 
			Destroy (this.gameObject);
		}

	}

	/**
	 * methods to change panda face to diffrent states 
	 */
	void awakeFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walkFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	void happyFace(){
		face.GetComponent<Animator> ().SetBool ("isSleeping", false);
		face.GetComponent<Animator> ().SetBool ("Happy", true);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walk(){
		walkFace ();
		rb.velocity = Vector2.right * speed;
	}
	/**
	 * public method to make panda walk off scene 
	 */
	public void finalWalk(){
		finalMove = true;
	}
	/**
	 * load next scene on pada destory
	 */
	void OnDestroy(){
		//Debug.Log ("Load next scene");
		SceneManager.LoadScene ("ExitScene");
	}

	/**
	 * test funcs
	 */

	void testGameObjectIsActive(GameObject _obj){

		Assert.IsTrue (_obj.activeSelf);

	}
	void testGameObjectIsNotActive(GameObject _obj){

		Assert.IsFalse (_obj.activeSelf);

	}
	void testPosition () {
		Assert.IsFalse (transform.localPosition.y < -10.5f);
	}

	void testCompRigidBody(){
		Assert.IsNotNull (transform.GetComponent<Rigidbody2D> ());
	}
	void testCompBoxCol(){
		Assert.IsNotNull (transform.GetComponent<BoxCollider2D> ());
	}
}

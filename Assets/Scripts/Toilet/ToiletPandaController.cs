/**
 * controller for player pnader in toileet scan scenes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class ToiletPandaController : MonoBehaviour {
	Animator anim;
	Rigidbody2D rb;
	bool walkIn = true;
	bool finalWalk;

	public GameObject face;
	public GameObject screen;
	public float speed;
	public GameObject screenPrompt;


	// Use this for initialization
	void Start () {
		walkIn = true;
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
//		testCompRigidBody ();
//		testCompBoxCol ();

		
	}
	
	// Update is called once per frame
	void Update () {
//		testPosition ();

		anim.SetFloat("Speed", rb.velocity.x);

		if (walkIn) { // inital walk in 
			Debug.Log ("adding velocity");
			rb.velocity = Vector2.left * speed;
			walkFace ();

		}

		if (transform.localPosition.x <= 2.4f && walkIn) { // panda walk in and stop at toilet 
			rb.velocity = new Vector2 (0, 0);
			walkIn = false;
			awakeFace ();
			screenPrompt.SetActive (true);
//			testGameObjectIsActive (screenPrompt);
			screen.GetComponent<BoxCollider2D> ().enabled = true;
	
		}
		if (finalWalk) { // final move test, after game select 
			Debug.Log ("FinalMove"); 
			rb.velocity = Vector2.right * speed;
			walkFace ();
		}
		if (transform.localPosition.x >= 9.5f) // kill panda off screen 
			Destroy (this.gameObject);
	}

	/**
	 * methods to change panda face to diffrent states 
	 */
	void awakeFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	void walkFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", false);
		face.GetComponent<Animator> ().SetBool ("Walking", true);
	}
	void happyFace(){
		face.GetComponent<Animator> ().SetBool ("Happy", true);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}
	/**
	 * methods to move panda to and from toilet
	 */
	public void moveUp(){
		Debug.Log ("moveUP called");
		transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y+1.0f, transform.localPosition.z);
	}

	public void moveDown(){
		Debug.Log ("moveUP called");
		transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y-1.0f, transform.localPosition.z);
	}
	/**
	 * public method to get panda to leave screen
	 */
	public void walkOff(){ 
		finalWalk = true;
	}

	/**
	 * method to call function in nextBtn script to load the next scene.
	 */
	void OnDestroy(){
		switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

		case "RENOGRAMin":
			SceneManager.LoadScene ("EndWaitingRoom");
			//TODO Next scene for Renogram Indirect branch 
			break;

		case "RENOGRAM":
			SceneManager.LoadScene ("MovingScan");
			//TODO Next scene for Renogram branch 
			break;

		default:
			SceneManager.LoadScene ("WaitingRoom");
			break;
		}
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

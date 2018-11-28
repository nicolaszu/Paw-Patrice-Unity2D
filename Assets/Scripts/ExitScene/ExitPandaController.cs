using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

//control the panda movements for the exit scene when the sliding door opens

public class ExitPandaController : MonoBehaviour {

	public float speed;
	public GameObject face;
	public GameObject leftDoor;

	Animator anim;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", rb.velocity.x);

		if (leftDoor.transform.position.x > -5 ) { //when the left door opens, the panda starts walking

			//testLeftDoorPosition ();
			rb.velocity = Vector2.right * speed;
			face.GetComponent<Animator> ().SetBool ("Walking", true);
			//testWalkingAnimationBool ();

		}

		if (transform.position.x > 10.5f ) { // test if panda is off screen to kill 

			//testExitPosition ();
			Destroy (this.gameObject);
			//testGameObjectNotActive (this.gameObject);

		}
		
	}

	void OnDestroy(){

		SceneManager.LoadScene ("ZoomOutExit");

	}

	//test functions

	void testExitPosition(){

		Assert.IsTrue (transform.position.x > 10.5f);

	}

	void testGameObjectNotActive(GameObject _obj){

		Assert.IsFalse (_obj.activeSelf);

	}

	void testLeftDoorPosition(){

		Assert.IsTrue (leftDoor.transform.position.x > -5);

	}

	void testWalkingAnimationBool(){

		Assert.AreEqual (true, face.GetComponent<Animator>().GetBool("Walking"));

	}

}

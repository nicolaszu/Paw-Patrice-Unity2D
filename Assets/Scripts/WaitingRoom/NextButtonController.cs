/**
 * this controls the next button on the speech bubble for UI interaction 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   //for loading scene 
using UnityEngine.Assertions;

public class NextButtonController : MonoBehaviour {

	public GameObject menu;
	public GameObject textOne;
	public GameObject textTwo;
	public GameObject speechBubble;
	public GameObject background; // background for transition
	public GameObject sofa;
	bool readyToMove;
	public WaitingRoom_Panda_Controller panda;

	float timeLeftforTransition=2;
	string itemTag;
	private int clicks = 0;

	void Start(){ // for fade

		readyToMove = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);

	}

	void Update(){ // for fade effect 
		
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		//Debug.Log (readyToMove);

		if (readyToMove) { // makes fade start !
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
		}

		if (timeLeftforTransition <= 0) {
			SceneManager.LoadScene ("AnestheticCream"); // load next scene 
		}

	}

	void OnMouseDown(){
		switch (clicks){

		case 0:// show menu 
			menu.SetActive (true);
			speechBubble.SetActive (false); 
			Destroy (textOne.gameObject);
			sofa.GetComponent<BoxCollider2D> ().enabled = false;

			testGameObjectIsNotActive (speechBubble);
			++clicks;
			break;
		case 1: // panda leave 
			//Debug.Log (tag);
			panda.walkOff ();// call to method to make panda walk away 
			Destroy (textOne.gameObject);
			Destroy (textTwo.gameObject);
			speechBubble.GetComponent<SpriteRenderer> ().enabled = false;
			transform.GetComponent<SpriteRenderer> ().enabled = false;
			break;

		default:
			break;
		}
	}
	/*
	 * setter for tag value- to save the procedure
	 */
	public void setTag(string _tag){

		itemTag = _tag;
	}
	/**
	 * method to laod new scene.
	 */
	public void loadNext(){
		//Debug.Log ("calling loadnext");
		//Debug.Log (itemTag);
		GameObject procedure =  GameObject.Find ("SceneManager");
		procedure.GetComponent<SceneManagerController> ().setProcedure(itemTag);
		readyToMove = true;

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
}

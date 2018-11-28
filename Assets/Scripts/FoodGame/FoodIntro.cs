using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

/*
 * This script renders and destroys objects/sprites depending on the clicks the user has made and how they proceed through the game
 */


public class FoodIntro : MonoBehaviour {

	private int click = 0;

	public GameObject speechBub;
	public GameObject text1;
	public GameObject text2;
	public GameObject arrow;
	public GameObject FoodInstructions;
	public GameObject startBtn;
	public GameObject background;
	public GameObject prompt;


	private bool firstClick = true;
	private bool readyToTransition;
	private bool interacted = false;

	public float wait;

	// Use this for initialization
	void Start () {
		StartCoroutine ("prompt_time");
		speechBub.SetActive (false); 

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && click == 0){ 
			//Debug.Log("0 button clicked" + firstClick);
			interacted = true; //stops prompt
			prompt.SetActive (false); //removes the prompt
			speechBub.SetActive(true); //speech bubble active if mouse pressed
			text1.SetActive(true); //text active at same time as speech bubble
			arrow.GetComponent<Renderer> ().enabled = true; //renders the arrow
			++click; //increases click number 
		}
	}


	void OnMouseDown(){
		//testMouseDown ();
		//Debug.Log ("Clicks:" + click);
		switch (click) {
		case 1:// show second text 
			//Debug.Log ("Panda Click event 2");
			Destroy (text1.gameObject); //destroys the first piece of text
			text2.SetActive (true); //activates the second piece of text
			++click; //clicks increase by one
			break;
		case 2:// show text 
			//Debug.Log ("Panda Click event 3");
			Destroy (text2.gameObject); //Destroys text 
			Destroy (speechBub.gameObject); //Destroys speech bubble
			FoodInstructions.GetComponent<Renderer> ().enabled = true;// renders instructions
			arrow.GetComponent<Renderer> ().enabled = false; //disables the arrow 
			startBtn.GetComponent<SpriteRenderer> ().enabled = true; //renders the start button sprite
			startBtn.GetComponent<StartBtnScript> ().enabled = true; // renders the start button script
			++click; //increments clicks
			break;

		}


	}

	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}

	//TESTS
//	void testMouseDown(){
//		Assert.IsTrue (OnMouseDown());
//	}

}

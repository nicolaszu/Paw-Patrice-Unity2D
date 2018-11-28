/**
 * script for UI menu game select, saves selected game to scenemanager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public GameObject prompt;
	public float wait;
	public WaitingRoom_Panda_Controller panda;
	public NextButtonController nextBtn;
	public GameObject speechBub;
	public GameObject text2Obj;
	public GameObject menu;
	public GameObject sofa;
	public Sprite text; 

	bool clicked = false;

	// Use this for initialization
	void Start () {
		//Debug.Log ("START!");
		StartCoroutine ("select_Prompt"); // start prompt enum
	}
	void OnMouseDown(){

		string tag = this.tag; // get the tag of object picked 
		//Debug.Log (tag);
		nextBtn.setTag (tag); // give tag to nextBtn 
		Destroy (menu.gameObject);
		Destroy (prompt.gameObject);
		text2Obj.SetActive (true);
		speechBub.SetActive (true);
		sofa.GetComponent<BoxCollider2D> ().enabled = true;
	}
	/*
	 * Enum for delay of menu select prompt 
	 */
	IEnumerator select_Prompt()
	{
		
		yield return new WaitForSeconds(wait);
		if (!(clicked)) { // if nothing is picked 
			//Debug.Log("Select prompt active");
			prompt.SetActive (true);
		}
	}

}

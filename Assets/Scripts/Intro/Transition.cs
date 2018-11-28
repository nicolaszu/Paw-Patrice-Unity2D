using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * This script allows for the transition between scenes so the player can move on through the game
 */

public class Transition : MonoBehaviour {

	public GameObject prompt;
	bool interacted;
	public float wait;


	// Use this for initialization
	void Start () {

		interacted = false;
		StartCoroutine ("prompt_time"); 
		
	}
	
	// Update is called once per frame
	void Update () {
			
			
	}

	void OnMouseDown(){

		interacted = true; // stops prompt 
		prompt.SetActive (false);
		
		SceneManager.LoadScene("WaitingRoom");

	}

	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}
}

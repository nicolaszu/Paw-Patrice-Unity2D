using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine;

//move scanning bed to the right side of screen along the x axis

public class MoveBedOut : MonoBehaviour {

	private Vector2 aPosition1;
	public GameObject background;
	float timeLeftforTransition=2;
	private bool readyForTransition;

	// Use this for initialization
	void Start () {

		aPosition1 = new Vector2 ( (float) 3, (float) -0.78); //position it will move to

		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		readyForTransition = false;

	}

	// Update is called once per frame
	void Update () {

		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), 
			aPosition1, 1 * Time.deltaTime);

		if (transform.position.x >= 3) {

			//testXPosition ();
			readyForTransition = true; //if the bed has moved out then start fade out

		}

		if (readyForTransition) {

			//testTransitionReady();
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;

		}
			
		if (timeLeftforTransition <= 0) {

			switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

			case "DMSA":
				Debug.Log("LOAD DMSA");
				SceneManager.LoadScene ("EndWaitingRoom");
				break;

			case "Meckel":
				Debug.Log("LOAD Meckel");
				SceneManager.LoadScene ("EndWaitingRoom");
				//TODO Next scene for Meckel branch 
				break;

			case "RENOGRAMin":
				SceneManager.LoadScene ("Toilet");
				//TODO Next scene for Renogram Indirect branch 
				break;

			case "RENOGRAM":
				SceneManager.LoadScene ("ToiletNoScan");
				//TODO Next scene for Renogram branch 
				break;

			default:
				SceneManager.LoadScene ("WaitingRoom");
				break;
			}

		}


	}

	//test functions

	void testTransitionReady(){

		Assert.IsTrue (readyForTransition);

	}

	void testXPosition(){

		Assert.IsTrue (transform.position.x >= 3);

	}


}

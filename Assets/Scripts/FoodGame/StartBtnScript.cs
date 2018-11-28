using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;


/*
 *This script creates the start button of the game, which also has a countdown and music attached. It then transitions to the next scene. 
 */


public class StartBtnScript : MonoBehaviour {

	public GameObject background;

	public Text time = null;
	float timeLeft = 3; //3 second timer
	private bool readyToTransition; //True when start button has been pressed
	private AudioSource source;


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		readyToTransition = false; //
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);

	}
	
	// Update is called once per frame
	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		if (readyToTransition) { //if start button has been clicked 
			//testReadyToTransition()

			if (!source.isPlaying&&timeLeft>2)
				source.Play ();
			
			if (timeLeft <= 1&&timeLeft>0) { 
				//testGO()
				timeLeft -= Time.deltaTime;
				time.text = "GO!";
			}

			else if(timeLeft<=0){
				//testReadytoLoadScene()
				background.SetActive (enabled);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
				Invoke ("loadScene", 1.5f);
			}
			else
			{
				timeLeft -= Time.deltaTime;
				changeText();
			}
		}
	}


	void OnMouseDown() { //on click boolean readyToTransition changes to true
		//Debug.Log ("Clicks on startBtn");
		readyToTransition = true;
	}

	void changeText() //changes the text in the countdown
	{
		time.text = "" + Mathf.Round(timeLeft);
	}

	void loadScene() //method to load to the next seen
	{
		SceneManager.LoadScene("FoodGame");
	}

	//TESTS
	void testReadyToTransition(){ 
		Assert.IsTrue (readyToTransition = true);
	}
	 
	void testReadytoLoadScene(){ 
		Assert.IsTrue (timeLeft <= 0);
	}
	void testGO(){ 
		Assert.IsTrue (timeLeft <= 1 && timeLeft > 0);
	}
}

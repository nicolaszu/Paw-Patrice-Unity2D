using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

//This script is in charge of the 45 second timer for the game as well as the fading of the scene
public class Timer : MonoBehaviour {
	
	private Text timer;
	public float timeLeft=5;
	private float timeLeftforTransition=4;
	public GameObject background;
	public GameObject endText;
	public CanvasGroup canvas;

	// Use this for initialization
	void Start () {
		timer = GetComponent<Text> ();
		timer.text = "TIMER: " + timeLeft;

		//this is in charge of the fading, it actually sets the intial colour that will later be faded in update
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
	}
	
	// Update is called once per frame
	void Update () {

		//this updates fading gameobject
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;

		//update text if timer is greater than 0
		if(Mathf.Round(timeLeft)>0){
		timeLeft -= Time.deltaTime;
		timer.text = "Timer: " + Mathf.Round (timeLeft);
		}

		//if game is over, activate endind text, and start fading after 2 seconds of the texts appearing
		else
        {
			endText.SetActive (true);
			timeLeftforTransition -= Time.deltaTime;
			if (timeLeftforTransition <= 2) { // start fade when this reaches 2 (originally 4)
				background.SetActive (enabled);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));//fades in a prefab with black material by changing the alpha

			}

			if (timeLeftforTransition <= 1.5) {
				canvas.alpha = 0; //erase UI on canvas
			}

			if (timeLeftforTransition <= 0) {
				SceneManager.LoadScene ("gameEnd"); //load celebration scene
			}
        }
        //testFade();
	}

	public float getTime(){
		return timeLeft; //get time left
	}

    //Test

    void testFade()
    {
        if (timeLeftforTransition <= 2)
        {
            Assert.IsTrue(background.active == true);
        } else

        if (timeLeftforTransition <= 1.5)
        {
            Assert.IsTrue(canvas.alpha == 0);
        } 
    }
}

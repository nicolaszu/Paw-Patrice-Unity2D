using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Button that will start the game when pressed
public class startRadiationGame : MonoBehaviour {

	public Button myButton;
	public Text time;
	float timeLeft;
	bool clicked;

	//initialising variables
	void Start() {
		timeLeft = 3;
		clicked = false;
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	//starting the countdown when the Start button is clicked. After the countdown Scene CatchRadiationGame is loaded
	void Update(){
		if (clicked) {
			if (Mathf.Round(timeLeft) == 0) {
				time.text = "GO!";
				timeLeft -= Time.deltaTime;
			}
			else if (Mathf.Round (timeLeft) == -1) SceneManager.LoadScene ("CatchRadiationGame");
			else {
				timeLeft -= Time.deltaTime;
				changeText ();
			}
		}
	}

	void TaskOnClick() {
		clicked = true;
	}

	void changeText() {
		time.text = "" + Mathf.Round(timeLeft);
	}
}

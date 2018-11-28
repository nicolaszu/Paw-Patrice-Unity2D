using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Button myButton;
	public Text time = null;
	float timeLeft = 5;
	bool clicked=false;

	void Start()
	{
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void Update(){
		if (clicked) {

			if (Mathf.Round(timeLeft) == 0)
			{
				time.text = "GO!";
				timeLeft -= Time.deltaTime;
			}
			else if (Mathf.Round (timeLeft) == -1) {
				SceneManager.LoadScene ("FoodGame");
			} 

			else {
				timeLeft -= Time.deltaTime;
				changeText ();
			}
		}
	}

	void TaskOnClick()
	{
		clicked = true;
	}

	void changeText()
	{
		time.text = "" + Mathf.Round(timeLeft);
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public GameObject background;
	float timeLeftforTransition=2;
	private bool readyToTransition;
	public Button myButton;

	void Start () {
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		//background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);fz
		Button btn = myButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}

	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		if (readyToTransition) {
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
		}

		if (timeLeftforTransition <= 0) {
			SceneManager.LoadScene ("FoodGame");
		}
	}


	public void TaskOnClick(){
		//Debug.Log ("Start button clicked");
		readyToTransition = true;
	}
}


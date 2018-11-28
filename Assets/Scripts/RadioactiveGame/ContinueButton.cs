using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class ContinueButton : MonoBehaviour {

	public GameObject background;
	float timeLeftforTransition;
	private bool readyToTransition;
	public Button tryAgainButton;
	public Text gameOverText;
	public Text winText;
	public Text CountText;
	public Text timeText;
	public Button rightArrow;
	public Button leftArrow;

	void Start () {
		timeLeftforTransition = 1;
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		gameObject.SetActive (false);
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		TestNotActive ();
	}

	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
		if (readyToTransition) {
			background.SetActive (enabled);
			tryAgainButton.gameObject.SetActive(false);
			gameOverText.text = "";
			winText.text = "";
			CountText.text = "";
			timeText.text = "";
			rightArrow.gameObject.SetActive (false);
			leftArrow.gameObject.SetActive (false);
			Vector3 pos = gameObject.transform.position;
			pos.x -= 10f;
			gameObject.transform.position = pos;
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
			Debug.Log (timeLeftforTransition);
		}
		if (timeLeftforTransition <= 0) SceneManager.LoadScene ("MovingScanOut");
	}

	void TaskOnClick(){
		TestActive ();
		readyToTransition = true;
	}
		
	//Tests 
	void TestActive() {
		Assert.IsTrue(gameObject.activeInHierarchy, "ContinueButton is not active.");
	}
	void TestNotActive() {
		Assert.IsFalse (gameObject.activeInHierarchy, "ContinueButton is active, but should not be.");
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/*
 This script is responsible for reactions based of touching the food.
*/

public class TouchFood : MonoBehaviour {

	public int scoreIncrease = 20;
	public float scoreDelay = 2;
	public static int foodScore;
	GameObject pandaFaceEmotionObject;
	GameObject normalFace;
	GameObject sadFace;
	GameObject food;
	float timeLeftAnimation=2;
	GameObject ScoreKeeperScoreBoard;
	ScoreKeeper scoreKeeper;
	Timer timerScript;
	SpriteRenderer spriteRenderer;
	private AudioSource source;
	bool sad=false;
	float nTime;

	// Use this for initialization
	void Start () {
		nTime = Time.time;
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		TestIsActive (pandaFaceEmotionObject);
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		timerScript = GameObject.Find ("Canvas/Timer").gameObject.GetComponent<Timer> ();
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();
		source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		TestScoreMultipleOf20();
		if (nTime < Time.time && timerScript.getTime() > 1) {
			scoreKeeper.Score += scoreIncrease;
			nTime = Time.time + scoreDelay;
		}

		if (sad) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				normalFace.SetActive (false);
				sadFace.SetActive (true);
				//TestIsActive (sadFace);
				//TestIsInactive (normalFace);
			} else {
				timeLeftAnimation = 2;
				sad = false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
				//TestIsActive (normalFace);
				//TestIsInactive (sadFace);
			}
		}
		foodScore = scoreKeeper.Score;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "Food" && timerScript.getTime() > 1){
				source.Play ();
				scoreKeeper.Score -=100;
				sad = true;
		}
	}

	//Tests
	void TestScoreMultipleOf20() {
		Assert.IsTrue (foodScore % 20 == 0);
	}
	void TestIsActive(GameObject go) {
		Assert.IsTrue (go.activeInHierarchy);
	}
	void TestIsInactive(GameObject go) {
		Assert.IsFalse (go.activeInHierarchy);
	}
}

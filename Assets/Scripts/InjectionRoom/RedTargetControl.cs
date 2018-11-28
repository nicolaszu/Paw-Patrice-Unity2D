using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

//Script in charge of all the things a red target does beside spawning
public class RedTargetControl : MonoBehaviour {

	//Panda Face
	private GameObject pandaFaceEmotionObject;
	private GameObject happyFace;
	private GameObject normalFace;
	private GameObject sadFace;
	private bool sad = false;
	private float timeLeftAnimation = 2;

	//Score board
	private GameObject ScoreKeeperScoreBoard;
	private ScoreKeeper scoreKeeper;

	//target components/temporary variable and stars
	private SpriteRenderer spriteRenderer;
	private CircleCollider2D coll;
	private GameObject instantiatedObj;
	public GameObject starCelebration;
	private float timeLeftTillDestroy = 3;

	//AudioSource
	private AudioSource source;

	// Use this for initialization
	void Start () {
		//Panda Face find componenets since its a prefab it cant be linked from inspector
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;

		//Score board
		ScoreKeeperScoreBoard = GameObject.Find ("Canvas/ScoreBoard").gameObject;
		scoreKeeper = ScoreKeeperScoreBoard.GetComponent<ScoreKeeper> ();

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
		coll = gameObject.GetComponent<CircleCollider2D> ();

		source = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		
		timeLeftTillDestroy -= Time.deltaTime;//decrease the amount of time until animation is destory by delta time

		//If target is hit then panda face is set to sad by disabling normal face and happy face gameobject and activiting sad face
		if (sad) {
			
			//if time left for animation is greater than 1 than set to sad face
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				happyFace.SetActive (false);
				normalFace.SetActive (false);
				sadFace.SetActive (true);
				//TestIsInactive (happyFace);
				//TestIsInactive (normalFace);
				//TestIsActive (sadFace);
			}
			//if less than 1 sec destroy target and also make panda face normal
			else {
				timeLeftAnimation = 2;
				sad= false;
				happyFace.SetActive (false);
				normalFace.SetActive (true);
				sadFace.SetActive (false);
				//TestIsInactive (happyFace);
				//TestIsInactive (sadFace);
				//TestIsActive (normalFace);
				Destroy (gameObject);
			}
		}

		//If target is not hit in designated time
		if (timeLeftTillDestroy <= 0) {
			scoreKeeper.Score += 100;
			Destroy (gameObject);
		}

	}

	//If target is clicked, play music, decrease score, set panda face to be sad in update 
	void OnMouseDown(){
		source.Play ();
		scoreKeeper.Score -=100;
		sad = true;
		spriteRenderer.enabled=false;
		coll.enabled = false;
	}
	//Tests
	void TestIsActive(GameObject go) {
		Assert.IsTrue (go.activeInHierarchy);
	}
	void TestIsInactive(GameObject go) {
		Assert.IsFalse (go.activeInHierarchy);
	}
}
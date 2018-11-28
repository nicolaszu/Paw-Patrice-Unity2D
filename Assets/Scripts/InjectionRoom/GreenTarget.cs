using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script in charge of all the things a green target does beside spawning
public class GreenTarget : MonoBehaviour {


	//Panda Face
	private GameObject pandaFaceEmotionObject;
	private GameObject happyFace;
	private GameObject normalFace;
	private GameObject sadFace;
	private bool happy=false;
	private float timeLeftAnimation=2;

	//Score board
	private GameObject ScoreKeeperScoreBoard;
	private ScoreKeeper scoreKeeper;

	//target components/temporary variable and stars
	private SpriteRenderer spriteRenderer;
	private CircleCollider2D coll;
	private GameObject instantiatedObj;
	public GameObject starCelebration;
	private float timeLeftTillDestroy=5;

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

		//If target is hit then panda face is set to happy by disabling normal face and sad face gameobject and activiting happy face
		if (happy) {

			//if time left for animation is greater than 1 than set to happy face
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				sadFace.SetActive (false);
				normalFace.SetActive (false);
				happyFace.SetActive (true);
			} 
			//if less than 1 sec destroy target(which by now has been replaced by stars) and also make panda face normal
			else {
				timeLeftAnimation = 2; //reset animation timer
				happy= false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
				happyFace.SetActive (false);
				Destroy (instantiatedObj);
				Destroy (gameObject);
			}
		}

		//If target is not hit in designated time
		if (timeLeftTillDestroy <= 0) {
			scoreKeeper.Score -=100;
			Destroy (gameObject);
		}

		
	}

	//If target is clicked, play music, increase score, turn target to star particle system and set panda face to be happy in update 
	void OnMouseDown(){
		source.Play ();
		scoreKeeper.Score +=100;
		happy = true;
		spriteRenderer.enabled = false;	
		coll.enabled = false;
		instantiatedObj= Instantiate(starCelebration,gameObject.transform.position,starCelebration.transform.rotation);
	}
		
}

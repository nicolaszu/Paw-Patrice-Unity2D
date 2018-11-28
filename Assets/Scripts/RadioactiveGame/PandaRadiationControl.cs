using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Assertions;

//class that describes the behaviour of the panda in the game, how it responds and how its surrounding respond to certain actions
public class PandaRadiationControl : MonoBehaviour {

	bool happy;
	bool sad;
	GameObject pandaFaceEmotionObject;
	GameObject happyFace;
	GameObject normalFace;
	GameObject sadFace;
	float timeLeftAnimation;
	public float speed;
	public GameObject face;
	public int count; 
	public Text countText;
	public Text winText;
	public Text gameOverText;
	public Text timerLabel;
	public float timeLeft;
	public Button tryAgainButton;
	public Button continueButton;
	public Button left;
	public Button right;
	public GameObject fiveCeleb;
	public GameObject fireLoseParticle;
	private GameObject instantiatedObj;
	private GameObject instantiatedObj2;
	float timeLeftTillDestroy;
	float timeLeftTillDestroyBomb;
	public Spawner spawner;
	private bool gameOver;
	private bool collidingleft;
	private bool collidingRight;
	private bool hitByBomb;
	private bool won=false;
	Animator anim;
	Rigidbody2D rb;
	GameObject thisGO;

	// Use this for initialization
	void Start() {
		//TestActive ();
		thisGO = gameObject;
		happy = false;
		sad = false;
		timeLeftAnimation = 2;
		timeLeftTillDestroy = 1;
		timeLeftTillDestroyBomb = 1;
		gameOver = false;
		collidingleft = false;
		collidingRight = false;
		hitByBomb = false;
		pandaFaceEmotionObject = GameObject.Find ("PandaFaceReaction");
		happyFace = pandaFaceEmotionObject.transform.Find ("Happy Face").gameObject;
		normalFace = pandaFaceEmotionObject.transform.Find ("Normal Face").gameObject;
		sadFace = pandaFaceEmotionObject.transform.Find ("SadFace").gameObject;
		ScoreKeeper.recentGame = "RadiationGame";
		Time.timeScale = 1;
		timeLeft = 30.0f;
		count = 0;
		SetCountText();
		//TestTextField ();
		winText.text = "";
		gameOverText.text = "";
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Making the panda move corresponding to the users keyboard and updating the time every frame.
	// This also handles the pandas facial expressions after the panda has collided with other GameObjects.
	void Update() {
		//TestValidTime ();
		anim.SetFloat ("Speed", rb.velocity.x);
		if (hitByBomb == false) {
			if (Input.GetKeyDown ("left") || Input.GetKeyDown("a")) WalkLeft ();
			if (Input.GetKeyUp ("left") || Input.GetKeyUp("a")) StopMoving ();
			if (Input.GetKeyDown ("right") ||  Input.GetKeyDown("d")) WalkRight ();
			if (Input.GetKeyUp ("right") || Input.GetKeyUp("d")) StopMoving ();
		}
		if (gameOver == false) timeLeft -= Time.deltaTime;
		timerLabel.text = "Timer: " + Mathf.Round(timeLeft);
		if(timeLeft < 0) {
			gameOverText.text = "Time over. Try again?";
			FinishGame ();
			//TestFinishGame();
		}
		if (instantiatedObj != null) {
			timeLeftTillDestroy -= Time.deltaTime;
			if (timeLeftTillDestroy <= 0) {
				Destroy (instantiatedObj);
				timeLeftTillDestroy = 1;
			}
		}
		if (instantiatedObj2 != null) {
			timeLeftTillDestroy -= Time.deltaTime;
			if (timeLeftTillDestroyBomb <= 0) {
				Destroy (instantiatedObj2);
				timeLeftTillDestroyBomb = 1;
			}
		}
		if (happy) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				sadFace.SetActive (false);
				normalFace.SetActive (false);
				happyFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				happy = false;
				sadFace.SetActive (false);
				normalFace.SetActive (true);
				happyFace.SetActive (false);
			}
		}
		if (sad) {
			if (timeLeftAnimation >= 1) {
				timeLeftAnimation -= Time.deltaTime;
				happyFace.SetActive (false);
				normalFace.SetActive (false);
				sadFace.SetActive (true);
			} 
			else {
				timeLeftAnimation = 2;
				sad = false;
				happyFace.SetActive (false);
				normalFace.SetActive (true);
				sadFace.SetActive (false);
			}
		}
	}

	//This handles the left and right boundaries of the screen which the panda cannot move through and also the collision with other gameObjects
	public void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.gameObject.name == "leftBoundary") {
			collidingleft = true;
			face.GetComponent<Animator> ().SetBool ("Walking", false);
		} else if (coll.transform.gameObject.name == "rightBoundary") {
			face.GetComponent<Animator> ().SetBool ("Walking", false);
			collidingRight = true;
		}
		else {
			Destroy (coll.gameObject);
			if(coll.gameObject.tag == "Collectable" && gameOver == false){ //when the panda collides with a radiation symbol count increases
				count = count + 1;
				happy = true;
				SetCountText ();
				//TestTextField ();
			}
			else if (coll.gameObject.tag == "Bamboo") { //when the panda collides with a bamboo timeLeft increases by 5 seconds
				happy = true;
				Vector3 pandaPos = new Vector3 (thisGO.transform.position.x, thisGO.transform.position.y, -2);
				instantiatedObj = Instantiate(fiveCeleb,pandaPos,fiveCeleb.transform.rotation);
				timeLeft += 5;
			} 
			else if (coll.gameObject.tag == "Cube") { //when the panda is hit by a bomb it is sad and the game is over
				sad = true;
				Vector3 bombPos = new Vector3 (coll.gameObject.transform.position.x, coll.gameObject.transform.position.y, -2);
				instantiatedObj2= Instantiate(fireLoseParticle,bombPos,fireLoseParticle.transform.rotation);
				if(!won)
				gameOverText.text = "You were hit by a bomb.\nTry again?";
				hitByBomb = true;
				StopMoving ();
				Destroy (left.GetComponent<EventTrigger> ());
				Destroy (right.GetComponent<EventTrigger> ());
				FinishGame ();
				//TestFinishGame();
			}
		}
	}

	//method that sets the count 
	public void SetCountText() {
		countText.text = count.ToString ();
		if (count >= 20) { //player has won
			won=true;
			winText.text = "You win! Captured all radiation!";
			face.GetComponent<Animator> ().SetBool ("Happy", true);
			FinishGame ();
			//TestFinishGame();
		}
	}

	//method that ends the game by stopping objects from falling from the sky and making te tryAgain and continueButton appear
	void FinishGame() {
		gameOver = true;
		spawner.CancelInvoke ();
		tryAgainButton.gameObject.SetActive (true);
		continueButton.gameObject.SetActive (true);
	}

	//method for the right arrow and left arrow buttons
	public void WalkLeft() {
		collidingRight = false;
		rb.velocity = Vector2.left * speed;
		if(collidingleft == false) face.GetComponent<Animator> ().SetBool ("Walking", true);
	}

	//method for the right arrow and left arrow buttons
	public void WalkRight() {
		collidingleft = false;
		rb.velocity = Vector2.right * speed;
		if(collidingRight == false) face.GetComponent<Animator> ().SetBool ("Walking", true);
	}

	//method for the right arrow and left arrow buttons
	public void StopMoving() {
		rb.velocity = new Vector2 (0, 0);
		face.GetComponent<Animator> ().SetBool ("Walking", false);
	}

	//Tests
	void TestActive() {
		Assert.IsTrue (gameObject.activeSelf, "Panda Game Object is not active.");
		Assert.IsTrue(face.activeInHierarchy, "Panda Face Game Object is not active.");
	}
	void TestValidTime() {
		Assert.AreNotEqual(-1, timeLeft, "Time is equal to 1, but should not be.");
		Assert.AreNotEqual(21, count, "Count is equal to 21, but should only go up to 20.");
	}
	void TestTextField() {
		Assert.AreEqual (count.ToString(), countText.text);
	}
	void TestFinishGame() {
		Assert.IsTrue (tryAgainButton.gameObject.activeInHierarchy, "tryAgainButton is not active, but it should be.");
	}
}
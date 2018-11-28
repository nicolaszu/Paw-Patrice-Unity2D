using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is in charge of the whole belt scene, animations +action on click
 */ 
public class BeltSceneController : MonoBehaviour {

	public GameObject background; //fading
	private int click = 1; //click for next action
	public Animator animScanner; //scanner machine animation
	public Animator animBelt; //belt animation
	public Animator animPanda; //panda face animation
	private float timeLeftforTransition=2; // fade starts
	private float timeLeftForMovingScanner=3; //time until scanner stops
	private bool readyToTransition; //ready to fade
	private bool startMovingTimer=false; 

	//prompts
	public GameObject prompt;
	private bool interacted = false;
	public float wait;
	private bool interacted2 = false;
	public float wait2;

	private AudioSource source;

	// Use this for initialization
	void Start () {
		readyToTransition = false;
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
		StartCoroutine ("prompt_time"); 
		source = GetComponent<AudioSource>();
		source.time = 3f; //start 3secs into sound
	}
	
	// Update is called once per frame
	void Update () {

		var material = background.GetComponent<Renderer> ().material;
		var color = material.color;
		if (readyToTransition) { //when scene is ready to fade and later transition
			background.SetActive (enabled);
			material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			timeLeftforTransition -= Time.deltaTime;
		}

		if (timeLeftforTransition <= 0) {
			SceneManager.LoadScene ("IntroCatchRadiationGame"); //next scene
		}

		if (startMovingTimer) { //scanner starts moving and later fades
			timeLeftForMovingScanner -= Time.deltaTime;
			if (timeLeftForMovingScanner <= 0) {
				readyToTransition = true;
				source.Stop ();
				startMovingTimer	 = false;
			}
		}
			
			
	
	}

	//On mouse click, move onto next action in scene if the past one is finished
	void OnMouseDown(){
		
			interacted = true; // stops first prompt 
			prompt.SetActive (false);
			
		if (click == 2) {
			interacted2 = true; //stops second prompt
		}

		switch (click) {

		case 1:// belt moves
			StartCoroutine ("prompt2_time"); //start timer for second prompt
			animBelt.SetTrigger ("attachBelt");// start belt animation
			++click;
			break;
		case 2:// machine starts
			if (animBelt.GetCurrentAnimatorStateInfo (0).IsName ("endIdle")) { //checks if last actions is finished
				source.Play ();
				interacted = true; // stops prompt 
				prompt.SetActive (false);
				animPanda.SetTrigger ("happy");
				animScanner.SetTrigger ("IsTimeToMove");
				startMovingTimer = true;
				++click;
				break;
			}
			break;

		}
	}

	IEnumerator prompt_time() //first prompt after 2 seconds 
	{
		yield return new WaitForSeconds(wait);
		if (!(interacted)) {
			prompt.SetActive (true);
		}
	}

	IEnumerator prompt2_time() //second prompt after 4 seconds + 1 click
	{
		yield return new WaitForSeconds(wait2);//4 seconds
		if (!(interacted2)) {
			prompt.SetActive (true);
		}
	}

}


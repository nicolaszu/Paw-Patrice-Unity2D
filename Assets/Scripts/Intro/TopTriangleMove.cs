using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Assertions;

/**This script is responsible for controlling the top triangle to allow the changing of sprites.
 * By changing the sprites over, the top triangle can move on its own to allow the envelope to open.
 * 
 */ 
public class TopTriangleMove : MonoBehaviour {

	private int clicks = 0;
	Animator anim;
	public GameObject frontLetter;
	public Sprite top;
    SpriteRenderer sp;
	private AudioSource source;
	bool clicked = false; 
	public float wait;
	public GameObject prompt;
	public GameObject prompt2;
	bool open = false;

	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	//sets the triggers to allow animation to move on and continue
	void Update () {
		if (!frontLetter.activeInHierarchy && !open) {
			source.Play ();
			clicked = true;
			anim.SetTrigger ("Open");
			anim.SetBool ("Opened", true);
			prompt.SetActive (false);
			//TestIsInactive(prompt);
			clicked = false;
			Destroy (prompt.gameObject);
			StartCoroutine ("prompt_time2");
			open = true;
		}
	}
		
	//depending on the no of clicks, a certain event happens.
	void OnMouseDown(){
		switch (clicks) {
		case 0:
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idletoptri")) {

				SceneManager.LoadScene ("OpenedLetter");
				++clicks;
				break;
			}
			break;
		default:
			break;
		}
	}

	//adds the top to the animation so it can be used later to open.
	void swapTop(){
		sp.sprite = top;
	}
	/**
	 * Enum to wait the given seconds argument before rendering the prompt
	 */
	IEnumerator prompt_time2()
	{
		yield return new WaitForSeconds(wait);
		if (!(clicked)) {
			prompt2.SetActive (true);
			//TestIsActive (prompt2);
		}
	}
	//Tests
	void TestIsActive(GameObject go) {
		Assert.IsTrue (go.activeInHierarchy);
	}
	void TestIsInactive(GameObject go) {
		Assert.IsFalse (go.activeInHierarchy);
	}
}
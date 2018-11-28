using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Assertions;

/*This script is used to move the letter in the envelope scene. 
 * The envelope moves and the triggers are set to to enable the animation to move on.
 * Prompts are also rendered after a certain time to help with moving through the game 
 *
 */

public class LetterMove : MonoBehaviour {

    Animator anim;
	SpriteRenderer sp;
	public Sprite back;
	private int clicks = 0;
	public Sprite openLet;
	public GameObject swapBottom;
	public GameObject swapTop;
	public GameObject prompt;
	public float wait;
	bool clicked = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetTrigger("Drop");
		anim.SetBool("Dropped",true);
		sp = GetComponent<SpriteRenderer>();
		StartCoroutine ("prompt_time");
	}
	
	void ChangeSprite(){
		sp.sprite = back;
	}

	void OnMouseDown(){
		switch (clicks){
		case 0:
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("IddleDropped")) {
				clicked = true;
				anim.SetTrigger ("flip");
				anim.SetBool ("flipped", true);
				prompt.SetActive (false);
				//TestIsInactive (prompt);
				prompt.GetComponent<Text> ().text = "Click to Open";
				++clicks;
				break;
			}
			break;
		
		 default:
			break;
		}
    }

	void swapobjects(){
		swapBottom.GetComponent<SpriteRenderer> ().enabled=true;
		swapTop.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.SetActive (false);
		//TestIsInactive (gameObject);
	}
	/**
	 * Enum to wait the given seconds argument before rendering the prompt
	 */
	IEnumerator prompt_time()
	{
		yield return new WaitForSeconds(wait);
		if (!(clicked)) {
			prompt.SetActive (true);
			//TestIsActive(prompt);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Enable colliders to allow for user interaction with game as a result of clicking the cream object

public class tapCream : MonoBehaviour {
    Texture2D texture;
    public Sprite sprite;
    public Collider2D[] colliders;
	public GameObject circles;
    public SpriteRenderer cursor = null;
    public Text text2 = null;
    public Text text3 = null;
	private AudioSource source;
  
    private void Start()
    {
		source = GetComponent<AudioSource>();
		source.time = 1f;
    }
    
	void Update () {
		if (source.time >= 2) {
			source.Stop ();
		}
    }

    private void OnMouseDown()
    {
		source.Play ();
        colliders[0].enabled = true; //As soon as the cream is clicked on we enable the colliders for the cream
        colliders[1].enabled = true; //so the panda can be interacted with
        colliders[2].enabled = true;
        colliders[3].enabled = true;
		circles.SetActive (true); //Activate circle to denote region for user to click on
        cursor.enabled = true; //Enable custom cursor image
        text2.enabled = false; //Change text
        text3.enabled = true;
    }
  
}

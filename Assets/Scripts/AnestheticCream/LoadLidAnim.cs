using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Load opening lid animation

public class LoadLidAnim : MonoBehaviour {

    public Animator anim = null;
    public Collider2D openCreamCol = null;
    public Text text = null;
    public Text text2 = null;
	private AudioSource source;


    private void Start()
    {
        anim = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
    }

 
    void OnMouseDown() //When lid of cream is clicked...
    {
		source.Play ();
        anim.Play("LidOpen"); //Play open lid animation
        openCreamCol.enabled = true; //Enable open cream collider to allow for clicking
        text.enabled = false; //Disable old text
        text2.enabled = true; //Enable new text

    }
}

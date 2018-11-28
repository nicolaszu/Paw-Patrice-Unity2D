using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodIntTrans : MonoBehaviour {

	public GameObject background;
	Button startButton;

	// Use this for initialization
	void Start () {
		var material1 = background.GetComponent<Renderer>().material;
		var color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
	}
	
	// Update is called once per frame
	void Update () {
		var material = background.GetComponent<Renderer>().material;
		var color = material.color;
	}
}

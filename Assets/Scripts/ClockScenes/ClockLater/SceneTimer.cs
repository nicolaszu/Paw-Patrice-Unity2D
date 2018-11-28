using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTimer : MonoBehaviour {
	public string sceneToLoad;
	public float waitTime = 6;
	public GameObject background;

	private float timeLeftForTransition = 6;
	private Material material;
	private Color color;

	// Use this for initialization
	void Start () {
		//set the transition time to the current time + waitTime seconds

		//fade code
		Material material1 = background.GetComponent<Renderer>().material;
		Color color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);
	}
	
	// Update is called once per frame
	void Update () {
			material = background.GetComponent<Renderer>().material;
			color = material.color;
			timeLeftForTransition -= Time.deltaTime;
			if (timeLeftForTransition <= 2) {
				background.SetActive (true);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			}

			if (timeLeftForTransition <= 0) {
				SceneManager.LoadScene ("MovingScanOut");
			}

	}
}

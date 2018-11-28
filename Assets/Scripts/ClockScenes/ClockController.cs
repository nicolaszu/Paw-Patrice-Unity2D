using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour {
	public string sceneToLoad;

	public GameObject wellDone;

	public GameObject cover;

	public GameObject background;

	public GameObject arrowObj;

	public GameObject minuteHand;
	public GameObject hourHand;

	public bool minuteDisabled;
	public bool hourDisabled;

	//ability to set the hour and minute snap from controller code, overrides individual settings
	public float minuteSnap = 0;
	public float hourSnap = 0;
	public float snapAngle = 20;

	//mode = 0 for moving minute hand, 1 for moving hour hand
	private int mode = 0;

	private GameObject minuteHint;
	private GameObject hourHint;

	private float waitUntil;
	private float timeLeftForTransition;
	private Material material;
	private Color color;

	public GameObject btnGameOb;
	public Button next;
	private bool readyToTrans=false;
	public CanvasGroup fadeCanvas;

	void Start() {
		//fade code
		Material material1 = background.GetComponent<Renderer>().material;
		Color color1 = material1.color;
		background.GetComponent<Renderer> ().material.color = new Color (color1.r, color1.g, color1.b, color1.a -color1.a);

		//setting up the child hand objects
		minuteHand.GetComponent<ClockHand> ().correctPos = minuteSnap;
		minuteHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		minuteHint = Instantiate (arrowObj, new Vector3 ((float) (4.2 * Mathf.Sin ((minuteSnap - 180) * Mathf.Deg2Rad) + 3), (float) (4 * Mathf.Cos (minuteSnap * Mathf.Deg2Rad)), 0), Quaternion.Euler (0, 0, minuteSnap));

		hourHand.GetComponent<ClockHand> ().correctPos = hourSnap;
		hourHand.GetComponent<ClockHand> ().snapAngle = snapAngle;

		hourHint = Instantiate (arrowObj, new Vector3((float) (4.2 * Mathf.Sin ((hourSnap - 180) * Mathf.Deg2Rad) + 3), (float) (4*Mathf.Cos(hourSnap * Mathf.Deg2Rad)),0), Quaternion.Euler(0,0,hourSnap));

		minuteHand.GetComponent<ClockHand>().isCorrect = minuteDisabled;
		hourHand.GetComponent<ClockHand>().isCorrect = hourDisabled;

		minuteHand.GetComponent<ClockHand> ().enabled = true;
		hourHand.GetComponent<ClockHand> ().enabled = true;

		cover.GetComponent<SpriteRenderer> ().enabled = false;

		if (minuteDisabled)
			mode = 1;

		if (mode == 0) {
			minuteHint.SetActive(true);
			hourHint.SetActive(false);
		} else if (mode == 1) {
			minuteHint.SetActive(false);
			hourHint.SetActive(true);
		} else {
			minuteHint.SetActive(false);
			hourHint.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if the mouse button is held down
		if (Input.GetMouseButtonDown (0)) {
			//move the appropriate clock hand to face the mouse
			if (mode == 0) {
				hourHand.GetComponent<ClockHand> ().canMove = false;
				minuteHand.GetComponent<ClockHand> ().canMove = true;
			} else if (mode == 1) {
				hourHand.GetComponent<ClockHand> ().canMove = true;
				minuteHand.GetComponent<ClockHand> ().canMove = false;
			}
		}

		//if the mouse button is released
		if (readyToTrans){
			Scene scene = SceneManager.GetActiveScene ();
			material = background.GetComponent<Renderer>().material;
			color = material.color;
			if(Time.time>waitUntil){
				timeLeftForTransition -= Time.deltaTime;
			}

			if (timeLeftForTransition <= 2) {
				background.SetActive (true);
				material.color = new Color (color.r, color.g, color.b, color.a + (1f * Time.deltaTime));
			}



			if (timeLeftForTransition <= 0) {
				fadeCanvas.alpha = 0;
				if (scene.name== "45minClockScene") {
					switch (SceneManagerController.Instance.getProcedure ()) { // switch dependant on selected game 

					case "DMSA":
						//Debug.Log ("LOAD DMSA");
						SceneManager.LoadScene ("Injection");
						break;

					case "Meckel":
						//Debug.Log ("LOAD Meckel");
						SceneManager.LoadScene ("Injection");
						//TODO Next scene for Meckel branch 
						break;

					case "RENOGRAMin":
						SceneManager.LoadScene ("Injection");
						//TODO Next scene for Renogram Indirect branch 
						break;

					case "RENOGRAM":
						SceneManager.LoadScene ("Injection");
						//TODO Next scene for Renogram branch 
						break;

					default:
						SceneManager.LoadScene (sceneToLoad);
						break;
					}
				} else {
					switch (SceneManagerController.Instance.getProcedure ()) {

					case "DMSA":
					//	Debug.Log ("LOAD DMSA");
						SceneManager.LoadScene ("ScanningRoom");
						break;
					default:
						SceneManager.LoadScene (sceneToLoad);
						break;
					}
				}
			}
		}


		//scene end code


		if (Input.GetMouseButtonUp (0)) {
			//disable the movement of the hands
			hourHand.GetComponent<ClockHand> ().canMove = false;
			minuteHand.GetComponent<ClockHand> ().canMove = false;

			//if the minute hand is correct, move to the second hand
			if (minuteHand.GetComponent<ClockHand> ().isCorrect) {
				mode = 1;
				minuteHint.SetActive(false);
				hourHint.SetActive(false);
			}

			//if the hour hand is correct, the clock is satisfied
			if (hourHand.GetComponent<ClockHand> ().isCorrect && minuteHand.GetComponent<ClockHand>().isCorrect&&Time.time>waitUntil) {
				//Debug.Log("Clock in satisfied state");
				minuteHint.SetActive(false);
				hourHint.SetActive(false);
				waitUntil = Time.time + 4;
				wellDone.GetComponent<SpriteRenderer> ().enabled = true;
				btnGameOb.SetActive (true);
				cover.GetComponent<SpriteRenderer> ().enabled = true;
				mode = 3;
			}
		}	
	}

	public void onClick(){
		readyToTrans = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script is in charge of the spawning of the targets on the pandas body, it randomises location between a specific area and it randomises what target will be creating,
 * Green targets spawn more than red targets.
 */ 
public class TargetCreationControl : MonoBehaviour {

	// Use this for initialization
	public GameObject redTarget;
	public GameObject greenTarget;
	private GameObject redTargetIn;
	private GameObject greenTargetIn;
	private float timeLeftTillNextSetOfTargets=0; //3 seconds set later

	//45 sec timer
	private GameObject timerKeeper;
	private Timer timer;

	//spawn area is betwween these empty objects
	public GameObject topRight;
	public GameObject BottomLeft;
	public GameObject topLeft;
	public GameObject BottomRight;

	// Use this for initialization
	void Start () {
		timerKeeper = GameObject.Find ("Canvas/Timer").gameObject;
		timer = timerKeeper.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (timer.getTime() > 0.5) {
			timeLeftTillNextSetOfTargets -= Time.deltaTime;//decrease time until next spawn


			if (timeLeftTillNextSetOfTargets <= 0) {//If ready for next spawn
				
				int whatColourTargt = Random.Range (0, 4); //red=1 green=0,2,3 picks what target colour to spawn next
				Vector3 screenPosition = new Vector3 (Random.Range (BottomLeft.transform.localPosition.x, topRight.transform.localPosition.x), Random.Range (BottomLeft.transform.localPosition.y, topRight.transform.localPosition.y), 0);//position of next target. Spawns somewehre between coordinates of 4 empty game objects

				if (whatColourTargt == 1) {
					redTargetIn=(GameObject) Instantiate(redTarget, screenPosition, redTarget.transform.rotation);

				} else if (whatColourTargt == 0||whatColourTargt == 2||whatColourTargt == 3) {
					greenTargetIn=(GameObject) Instantiate (greenTarget, screenPosition, redTarget.transform.rotation);
				}

				timeLeftTillNextSetOfTargets = 3;//restart timer for next target
			}
		}


		//Destroy targets if game is over
		else if (timer.getTime()<=0.5){
			Destroy (greenTargetIn);
			Destroy(redTargetIn);
		}
	}


		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*This script is in charge of creating the 321 counter in injection scene once start is clicked
 */
public class countdown : MonoBehaviour {

    public Text time = null;
	public GameObject timeGameObj;//created to facilitate appearance of text since its UI
    private float timeLeft = 3;//3 seconds
	public AudioSource source;

	void Start () {
		timeGameObj.SetActive (true);//show timer
		source.Play ();//play sound
	}

    void Update()
    {
		if (timeLeft <= 1&&timeLeft>0) {
			timeLeft -= Time.deltaTime;
			time.text = "GO!";//If it reaches 1 change text to Go and play
		}

		else if(timeLeft<=0)
			SceneManager.LoadScene("InjectionGame");// load injection game
		
        else
        {
            timeLeft -= Time.deltaTime;
            changeText();//change text to new time rounded
        }
    }

	//Round time to nearest second
    void changeText()
    {
        time.text = "" + Mathf.Round(timeLeft);
    }
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEndNext : MonoBehaviour {

    public bool clicked = false;
	// Use this for initialization
	void Start () {
        if (ScoreKeeper.recentGame == "FoodGame")
        {
			switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

			case "Meckel":
				SceneManager.LoadScene ("ScanningRoom");
				//TODO Next scene for Meckel branch 
				break;


			default:
				SceneManager.LoadScene ("WaitingRoom");
				break;
			}
		
        }
        else
        if (ScoreKeeper.recentGame == "InjectionGame")
        {
			switch (SceneManagerController.Instance.getProcedure()) { // switch dependant on selected game 

			case "DMSA":
				Debug.Log("LOAD DMSA");
				SceneManager.LoadScene ("3hrClockScene");
				break;

			case "Meckel":
				Debug.Log("LOAD Meckel");
				SceneManager.LoadScene ("FoodGameIntroduction");
				//TODO Next scene for Meckel branch 
				break;

			case "RENOGRAMin":
				SceneManager.LoadScene ("ScanningRoom");
				//TODO Next scene for Renogram Indirect branch 
				break;

			case "RENOGRAM":
				SceneManager.LoadScene ("ScanningRoom");
				//TODO Next scene for Renogram branch 
				break;

			default:
				SceneManager.LoadScene ("WaitingRoom");
				break;
			}
		}
        	 
    }
}

   

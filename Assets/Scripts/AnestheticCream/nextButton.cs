using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Reset incremented values and loading new scene

public class nextButton : MonoBehaviour {

	void Start () {
        creamTransparency.leftArmVal = 0; //Reset the values of cream transparency so when the game is played again
        creamTransparency.leftLegVal = 0; //the transparency doesn't remain
        creamTransparency.rightArmVal = 0;
        creamTransparency.rightLegVal = 0;
        SceneManager.LoadScene("45minClockScene"); //Load new scene
    }

}

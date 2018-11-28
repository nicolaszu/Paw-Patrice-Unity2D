using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set custom cursor

public class cursor : MonoBehaviour {

    void Start () {
		
	}
	
	void Update () { //Set custom cursor image to follow actual cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosNeed = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        mousePosNeed.z = 5f;
        transform.position = mousePosNeed;
    }

}

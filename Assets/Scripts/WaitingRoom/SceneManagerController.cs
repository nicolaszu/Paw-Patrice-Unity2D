/**
 * This script saves the procedure the player selects, its never deleted on scene load and is a 
 * singleton.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SceneManagerController : MonoBehaviour {
	public static SceneManagerController Instance = null;
	public static int count = 0;
	private string procedure ; // saves procedure 

	/**
	 * singleton object- can only ever be one instance of this 
	 */
	void Awake()
	{
		if (Instance == null) { // only have one instance of this object 
			Instance = this;
			++count;
			DontDestroyOnLoad (gameObject); // game object never destroyed between scenes 
		} else {
			DestroyImmediate (gameObject);
		}
//		testSingleton();
	}
	/**
	 * public mehtod to get the procedure - for loading scenes
	 */
	public string getProcedure(){

		return procedure;
	}
	/**
	 * method to set procedure
	 */
	public void setProcedure(string _procedure){

		procedure = _procedure;
	}

	/**
	 * test func
	 */
	void testSingleton(){
		Assert.AreEqual (1, count, "There is more than one sceneManager eeeeK!");
	}


}

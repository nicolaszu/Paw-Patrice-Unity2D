using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that spawns objects that will fall from the sky and for the panda to collect / dodge
public class Spawner : MonoBehaviour {

	private float delayRays;
	private float delayBamboos;
	private float delayCubes;
	public GameObject RadioActive;
	public GameObject Bamboo;
	public GameObject Cube;

	void Start() {
		delayRays = 1f;
		delayBamboos = 6.8f;
		delayCubes = 2.3f;
		InvokeRepeating ("Spawn1", delayRays, delayRays);
		InvokeRepeating ("Spawn2", delayBamboos, delayBamboos);
		InvokeRepeating ("Spawn3", delayCubes, delayCubes);
	}

	void Spawn1() {
		Instantiate (RadioActive, new Vector3 (Random.Range (-6, 6), 5, 0), Quaternion.identity);
	}
	void Spawn2() {
		Instantiate (Bamboo, new Vector3 (Random.Range (-6, 6), 5, 0), Quaternion.identity);
	}
	void Spawn3() {
		Instantiate (Cube, new Vector3 (Random.Range (-4, 4), 5, 0), Quaternion.identity);
	}
}
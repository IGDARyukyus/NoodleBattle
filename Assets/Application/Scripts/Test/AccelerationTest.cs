using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTest : MonoBehaviour {

	private float Power = 10f;
	private GameObject[] noodles;

	private void Start () {
		noodles = GameObject.FindGameObjectsWithTag ("Noodle");
	}

	// Update is called once per frame
	void Update () {
		Vector3 dy = Input.acceleration;
	}

	void AddPower (float pow) {
		for (int i = 0; i < noodles.Length; i++) {
	
		}	
	}
}

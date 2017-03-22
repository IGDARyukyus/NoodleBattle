using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTest : MonoBehaviour {

	[SerializeField]private float MAGUNITUDE = 2F;
	private float Power = 50f;
	private Noodles[] noodles;

	private void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Noodle");
		noodles = new Noodles[objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			noodles [i] = objs [i].GetComponent<Noodles> ();
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 acceleration = Input.acceleration;
		float magnitude = acceleration.magnitude;
		print (magnitude);
		if (magnitude > MAGUNITUDE) {
			AddPower (-acceleration);
		}
	}

	void AddPower (Vector3 pow) {
		for (int i = 0; i < noodles.Length; i++) {
			noodles [i].AddPower (pow * Power);
		}
	}
}

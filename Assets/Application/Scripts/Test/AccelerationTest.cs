using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTest : MonoBehaviour {

	private float MAGUNITUDE = 2f;
	private float Power = 500f;
	private Noodles[] noodles;

	// Debug Mode.
	public bool isSwing = false;

	private void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Noodle");
		noodles = new Noodles[objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			noodles [i] = objs [i].GetComponent<Noodles> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (MakeManager.instance.isPlay) {
			Vector3 acceleration = Input.acceleration;
			print (acceleration);
			float magnitude = acceleration.magnitude;
			if (magnitude > MAGUNITUDE) {
				if (isSwing) {
					AddPower (acceleration);
				} else {
					AddFirstPower (acceleration);
				}
			}

			if (CheckRotate (acceleration.x)) {
				print ("End");
				MakeManager.instance.isPlay = false;
			}
		}
	}

	void AddPower (Vector3 pow) {
		// Handheld.Vibrate ();
		MakeManager.instance.score.AddToCount ();
		MakeManager.instance.score.SubToWater (pow.magnitude);
		print (-pow * Power);
		for (int i = 0; i < noodles.Length; i++) {
			noodles [i].AddPower (-pow * Power);
		}
	}

	void AddFirstPower (Vector3 pow) {
		isSwing = true;
		MakeManager.instance.score.AddToCount ();
		MakeManager.instance.score.SubToWater (pow.magnitude);

		for (int i = 0; i < noodles.Length; i++) {
			noodles [i].AddPower (pow * Power);
		}

		float t = MakeManager.instance.score.StopTimer ();
		print (t);
	}

	private bool CheckRotate (float dx) {
		if (dx > 0.8f)
			return true;
		return false;
	}
}

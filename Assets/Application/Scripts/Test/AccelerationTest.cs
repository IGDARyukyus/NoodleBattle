using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationTest : MonoBehaviour {

	public MakeManager makeManager;
	private float MAGUNITUDE = 2f;
	private float Power = 100f;
	[SerializeField]private Noodles[] noodles;

	// Debug Mode.
	public bool isSwing = false;

	private void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Noodle_Single");
		noodles = new Noodles[objs.Length];
		for (int i = 0; i < objs.Length; i++) {
			noodles [i] = objs [i].GetComponent<Noodles> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (makeManager.isPlay) {
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

//			if (CheckRotate (acceleration.x)) {
//				print ("End");
//				makeManager.isPlay = false;
//			}
		}
	}

	void AddPower (Vector3 pow) {
		// Handheld.Vibrate ();
		makeManager.score.AddToCount ();
		makeManager.score.SubToWater (pow.magnitude);
		print (-pow * Power);
		for (int i = 0; i < noodles.Length; i++) {
			noodles [i].AddPower (-pow * Power);
		}
	}

	void AddFirstPower (Vector3 pow) {
		isSwing = true;
		makeManager.score.AddToCount ();
		makeManager.score.SubToWater (pow.magnitude);

		for (int i = 0; i < noodles.Length; i++) {
			noodles [i].AddPower (-pow * Power);
		}
	}

	private bool CheckRotate (float dx) {
		if (dx > 0.8f)
			return true;
		return false;
	}
}

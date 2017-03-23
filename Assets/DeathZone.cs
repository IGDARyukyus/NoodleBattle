using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

	private void OnTriggerEnter (Collider col) {
		if (col.tag == "Noodle_Single") {
			Destroy (col.gameObject);
		}
	}
}

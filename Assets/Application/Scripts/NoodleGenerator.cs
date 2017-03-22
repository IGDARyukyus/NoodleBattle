using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleGenerator : MonoBehaviour {

	private int count = 10;
	public GameObject noodle;
	[SerializeField] private float Times = 1f;
	// Use this for initialization
	IEnumerator Start () {
		int i = 0;
		while (i < count) {
			GameObject obj = Instantiate (noodle, transform.position, noodle.transform.rotation);
			obj.AddComponent<PhotonView> ();
			yield return new WaitForSeconds (Times);
			i++;
		}
	}
}

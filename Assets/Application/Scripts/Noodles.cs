using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : MonoBehaviour {

	private Rigidbody[] noodles;
	[SerializeField]private bool isGround = false;

	// Use this for initialization
	void Start () {
		int count = transform.childCount;
		noodles = new Rigidbody[count];

		for (int i = 0; i < count; i++) {
			noodles [i] = transform.GetChild (i).GetComponent<Rigidbody> ();
		}
	}

	public void AddPower (Vector3 p)
	{
		for (int i = 0; i < transform.childCount; i++) {
			noodles [i].AddForce (p);
		}

	}
}
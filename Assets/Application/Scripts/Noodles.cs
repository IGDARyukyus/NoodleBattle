using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : MonoBehaviour {

	private Rigidbody noodle;
	[SerializeField]private bool isGround = false;
	[SerializeField]private float Scale = 0.2f;
	[SerializeField]private float Mass = 0.1f;

	// Use this for initialization
	void Start () {
		Settings ();
	}
	
	public void AddPower (Vector3 p)
	{
		noodle.AddForce (p);
	}

	public void Settings() {
		noodle = GetComponent<Rigidbody> ();
		noodle.mass = Mass;
		transform.localScale = Vector3.right * Scale + Vector3.up * transform.localScale.y + Vector3.forward * Scale;
	}
}
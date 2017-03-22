using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : MonoBehaviour {

//	private Rigidbody[] noodles;
//	[SerializeField]private bool isGround = false;
//	[SerializeField]private float Scale = 0.2f;
//	[SerializeField]private float Mass = 0.1f;

	private Rigidbody noodle;
	[SerializeField]private bool isGround = false;
	[SerializeField]private float Scale = 0.2f;
	[SerializeField]private float Mass = 0.1f;


//	// Use this for initialization
//	void Start () {
//		int count = transform.childCount;
//		noodles = new Rigidbody[count];
//
//		for (int i = 0; i < count; i++) {
//			noodles [i] = transform.GetChild (i).GetComponent<Rigidbody> ();
//		}
//
//		Settings ();
//	}
//
//	public void AddPower (Vector3 p)
//	{
//		for (int i = 0; i < transform.childCount; i++) {
//			noodles [i].AddForce (p);
//		}
//	}
//
//	public void Settings() {
//		for (int i = 0; i < transform.childCount; i++) {
//			noodles [i].gameObject.transform.localScale = Vector3.right * Scale + Vector3.up * 0.25f + Vector3.forward * Scale;
//			noodles [i].GetComponent<Rigidbody> ().mass = Mass;
//		}
//	}

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
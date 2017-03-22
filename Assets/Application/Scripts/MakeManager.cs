using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeManager : MonoBehaviour {

	public static MakeManager instance;

	private readonly float BEST_WATER = 20f;
	private readonly int BEST_COUNTER = 5;

	private float Water = 100f;
	private int Counter = 0;

	private void Awake () {
		if (instance == null)
			instance = this;
	}

	public void AddToCount() {
		Counter++;
		print ("Counter : " + Counter);
	}

	public void SubToWater (float sub) {
		Water -= sub;
		print ("Water : " + Water);
	}
}

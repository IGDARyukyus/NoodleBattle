using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {
//	private readonly float BEST_WATER = 20f;
//	private readonly int BEST_COUNTER = 5;

	private readonly float BASE_WATER = 100f;

	private float Water = 100f;
	private float Temp = 100f;
	private float LateTimer = 0f;
	private int   Counter = 0;
	[SerializeField]private float DryingPercent = 10f;

	private bool isTimer = false;
	private bool isRiftup = false;

	private void Update () {
		if (isTimer) {
			LateTimer += Time.deltaTime;
		}

		if (isRiftup) {
			Water -= Time.deltaTime / DryingPercent;
		}
	}

	public void StartTimer () {
		isTimer = true;
		isRiftup = true;
	}

	public float StopTimer () {
		isTimer = false;
		return LateTimer;
	}

	public void AddToCount() {
		Counter++;
		print ("Counter : " + Counter);
	}

	public void SubToWater (float sub) {
		Water -= sub;
		print ("Water : " + Water);
	}

	public float getPercentageOfWater () {
		return Water / BASE_WATER;
	}
}

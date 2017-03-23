using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour {
//	private readonly float BEST_WATER = 20f;
//	private readonly int BEST_COUNTER = 5;

	private readonly float BASE_WATER = 500f;

	private float Water = 500f;
	private int   Counter = 0;
	[SerializeField]private float DryingPercent = 10f;
	private Scores myScore;

	private bool isRiftup = false;

	private void Update () {
		if (MakeManager.instance.isPlay) {

			if (isRiftup) {
				Water -= Time.deltaTime / DryingPercent;
			}
		}
	}

	public void StartTimer () {
		isRiftup = true;
	}

	// シェイクの回数は多いほうがいい
	public void AddToCount() {
		Counter++;
		print ("Counter : " + Counter);
	}

	// 油を落としきった後の残り本数
	public void SubToWater (float sub) {
		Water -= sub;
		print ("Water : " + Water);
	}

	public float getPercentageOfWater () {
		return Water / BASE_WATER;
	}
}

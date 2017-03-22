using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeManager : MonoBehaviour {

	public static MakeManager instance;

	[HideInInspector]public Scores score;
	public Text text;
	public Image water_percent_gage;

	private string[] texts = { "Ready...", "Go！湯切れ！"};
	private int text_number = 0;

	private void Awake () {
		if (instance == null)
			instance = this;
		score = GetComponent<Scores> ();
	}

	// ランダムで○秒後に振動を与える
	private IEnumerator Start () {
		float ran = Random.Range (5f, 20f);
		yield return new WaitForSeconds (ran);
		text_number++;
		Handheld.Vibrate ();
		score.StartTimer ();
	}

	private void Update () {
		ChangeText ();
		ChangePercent ();
	}

	private void ChangeText () {
		text.text = texts [text_number];
	}

	private void ChangePercent () {
		water_percent_gage.fillAmount = score.getPercentageOfWater ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeManager : MonoBehaviour {

	public static MakeManager instance;
	public bool isPlay = false;

	[HideInInspector]public Scores score;
	public Text text;
	public Image water_percent_gage;

	private string[] texts = {"マッチング中" ,"Ready...", "Go！"};
	private int text_number = 0;

	private void Awake () {
		if (instance == null)
			instance = this;
		score = GetComponent<Scores> ();
	}

	// ランダムで○秒後に振動を与える
	private IEnumerator Start () {
		while (!isMatchingRoom ()) {
			yield return null;
		}
		AddOneToNumber (text_number);
		float ran = Random.Range (5f, 20f);
		yield return new WaitForSeconds (ran);
		AddOneToNumber (text_number);
		isPlay = true;
		#if !UNITY_STANDALONE_WIN
		Handheld.Vibrate ();
		#endif
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

	private bool isMatchingRoom () {

		print("RoomName : " + PhotonNetwork.room.Name);
		print ("User count : " + PhotonNetwork.room.PlayerCount);

		if (PhotonNetwork.room.PlayerCount == 2) {
			return true;
		} else {
			return false;
		}
	}

	private void AddOneToNumber (int n) {
		n = n + 1;
	}

	// ゲームを閉じた時に行う処理(Androidのバックグラウンドでは動かない)
	private void OnApplicationQuit() {
		PhotonNetwork.LeaveRoom ();
	}

	// AndroidやIOSの場合はこれが必要
	void OnApplicationPause (bool pauseStatus)
	{
		if (pauseStatus) {
			PhotonNetwork.LeaveRoom ();
		}
	}
}

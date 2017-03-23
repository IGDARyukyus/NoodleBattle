using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MakeManager : MonoBehaviour {

	public bool isPlay = false;

	[HideInInspector]public Scores score;
	public Text text;
	public Image water_percent_gage;

	private string[] texts = {"マッチング中" , "Go！"};
	private int text_number = 0;

	private bool isfirst = false;
	private bool isChecked = false;

	public NoodleGenerator noodleg;

	public Canvas ShowTurnCanvas;

	private PhotonView view;
	private PhotonView mainView;

	// Game要素
	private readonly float BASE_TIMER = 10f;
	public static float GameTimes = 0;

	public enum Type
	{
		CREATE,
		EAT
	}

	private Type playtype;
	public static Type nowGameType;


	private void Awake () {
		isOwnerCheck ();

		// photonviewでゲージを共有
		view = water_percent_gage.GetComponent<PhotonView> ();

		// 先攻はCreate
		nowGameType = Type.CREATE;
	}

	private void Update () {

		// nowGameTypeが自分のTypeと同じならば動く
		if (playtype == nowGameType) {
			if (!isChecked) {
				isMatchingRoom ();
			}

			if (!isPlay) {
				if (isfirst) {
					isfirst = false;
					text_number++;
					isPlay = true;
					score.StartTimer ();
					ShowTurnCanvas.enabled = false;
				}
			} else {
				GameTimes += Time.deltaTime;
				if (GameTimes > BASE_TIMER) {
					isPlay = false;
					if (playtype == Type.CREATE) {
						mainView.RPC ("Switch", PhotonTargets.All, Type.EAT);
					} else {
						mainView.RPC ("Switch", PhotonTargets.All, Type.CREATE);
					}
				}
				view.RPC ("ChangePercent", PhotonTargets.All, score.getPercentageOfWater());
			}

			ChangeText ();
		} else {
			ShowTurnCanvas.enabled = true;
		}
	}

	private void ChangeText () {
		text.text = texts [text_number];
	}

	private void isMatchingRoom () {

		if (PhotonNetwork.room.PlayerCount == 2) {
			isfirst = true;
			isChecked = false;
		}
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

	private void isOwnerCheck () {
		PhotonPlayer pp = PhotonNetwork.player;
		if (pp.IsMasterClient) {
			print ("あなたは先攻です。");
			score = PhotonNetwork.Instantiate ("Score", transform.position, transform.rotation, 0).GetComponent<Scores>();
			playtype = Type.CREATE;
		} else {
			print("あなたは後攻です。");
			playtype = Type.EAT;
		}
	}

	[PunRPC]
	private void Switch(Type type) {
		nowGameType = type;
		GameTimes = 0f;
		print ("攻守交代");
		SceneManager.LoadScene (1);
	}
}

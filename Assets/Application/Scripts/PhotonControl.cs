using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonControl : MonoBehaviour {


	private int roomNumber = 1;
	private string roomName = "Battle";
	private string photonVersionNumber = "1.0";

	private void Start () {
		PhotonNetwork.ConnectUsingSettings (photonVersionNumber);
	}

	public void SearchRoom () {
		RoomOptions options = new RoomOptions ();
		options.MaxPlayers = 2;
		options.IsOpen = true;

		if (PhotonNetwork.JoinOrCreateRoom (roomName + roomNumber.ToString (), options, TypedLobby.Default)) {
			print ("Connect Complete. " + roomName + roomNumber);
		} else {
			print ("retry!");
			roomNumber++;
			SearchRoom ();
		}
	}

   void OnJoinedRoom () {
		StartCoroutine (LoadScene(2.0f));
	}

	private IEnumerator LoadScene( float i_time )
	{
		// 一定時間経ってからシーンを読む.
		yield return new WaitForSeconds( i_time );
		SceneManager.LoadScene( "make_main" );
	}
}

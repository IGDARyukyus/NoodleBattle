using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gage : MonoBehaviour {

	private Image gage;

	private void Start () {
		gage = GetComponent<Image> ();
	}

	[PunRPC]
	private void ChangePercent (float val) {
		gage.fillAmount = val;
	}
}

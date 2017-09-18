using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPing : MonoBehaviour {
	[Header("Assign Ping Text")]
	public Text Pingtext;
	
	// Update is called once per frame
	void Update () {
		Pingtext.text= PhotonNetwork.networkingPeer.RoundTripTime.ToString();
	}
}

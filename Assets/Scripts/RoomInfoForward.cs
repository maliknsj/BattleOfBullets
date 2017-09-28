using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomInfoForward : MonoBehaviour {
	public static string RoomName;
	public InputField RoomNameField;
	public static string Mode;
	public InputField PlayerNameField;

	public void Getinfo(){
		RoomName = RoomNameField.transform.Find ("Text").GetComponent<Text> ().text;
		PhotonNetwork.playerName = PlayerNameField.transform.Find ("Text").GetComponent<Text> ().text;
	}
}

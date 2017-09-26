using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomList : MonoBehaviour {
	public GameObject RoomBoardEntry;
	public GameObject RoomBoardPanelParent;


	void Start(){
		PhotonNetwork.ConnectUsingSettings ("Version 01");
	}

//	void OnGUI(){
//		foreach (RoomInfo room in PhotonNetwork.GetRoomList()) {
//			if (GUILayout.Button (room.Name.ToString ())) {
//				PhotonNetwork.JoinRoom (room.Name);
//			}
//		}
//	}

	void OnReceivedRoomListUpdate(){
		foreach (RoomInfo room in PhotonNetwork.GetRoomList()) {
			GameObject RoomObject = (GameObject)Instantiate (RoomBoardEntry);
			RoomObject.transform.SetParent (RoomBoardPanelParent.transform);
			RoomObject.transform.Find ("NameHeader").GetComponent<Text> ().text = room.name;
			RoomObject.transform.Find ("CurrentPlayersHeader").GetComponent<Text>().text = room.PlayerCount.ToString();
			RoomObject.transform.Find ("TotalPlayersHeader").GetComponent<Text>().text = room.MaxPlayers.ToString();
		}
	}

	public void ShowJoinText(){
		GameObject.Find ("JoinText").transform.position =  Input.mousePosition;
		GameObject.Find ("JoinText").GetComponent<CanvasGroup> ().alpha = 1;
	}

	public void HideJoinText(){
		GameObject.Find ("JoinText").GetComponent<CanvasGroup> ().alpha = 0;
	}
}
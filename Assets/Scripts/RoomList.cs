using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomList : Photon.PunBehaviour {
	public GameObject RoomBoardEntry;
	public GameObject RoomBoardPanelParent;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
			foreach (RoomInfo room in PhotonNetwork.GetRoomList()) {
				Debug.Log (room.Name+ " Name ");
				GameObject RoomObject = (GameObject)Instantiate (RoomBoardEntry);
				RoomObject.transform.SetParent (RoomBoardPanelParent.transform);
				RoomObject.transform.Find ("NameHeader").GetComponent<Text> ().text = room.name;
			}
	}

	void OnReceivedRoomListUpdate (){ 	


	}
}
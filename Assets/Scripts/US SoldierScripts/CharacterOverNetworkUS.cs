﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverNetworkUS : Photon.MonoBehaviour {
	Vector3 Position = Vector3.zero;
	Quaternion Rotation = Quaternion.identity;
	Animator anim;
	GameObject MeshCleaner;

	bool FirstUpdate = false;
	// Use this for initialization
	void Start () {
		anim = transform.Find ("USSOLDIER").GetComponent<Animator> ();
		MeshCleaner = transform.Find ("USSOLDIER").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			//Do Nothing
			transform.Find("GunCamera").gameObject.SetActive(true);
			MeshCleaner.transform.Find ("Bip001").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("Soldier_01_LOD0").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("Soldier_01_LOD1").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("Soldier_01_LOD2").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("Soldier_01_LOD3").gameObject.SetActive (false);

		}
		else {
			transform.Find("GunCamera").gameObject.SetActive(false);
			MeshCleaner.transform.Find ("Bip001").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("Soldier_01_LOD0").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("Soldier_01_LOD1").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("Soldier_01_LOD2").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("Soldier_01_LOD3").gameObject.SetActive (true);
			transform.position = Vector3.Lerp (transform.position, Position, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, Rotation, 0.1f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			//this is our player we need to send current position to the netwrok
			stream.SendNext(transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (anim.GetInteger("Walk"));
			stream.SendNext (anim.GetBool("Jump"));
			stream.SendNext (anim.GetBool ("Reload"));

		} 
		else {
			//This is Enemy's player we need to receive data from them
			if (FirstUpdate == false) {
				transform.position = Position;
				transform.rotation = Rotation;
				FirstUpdate = true;
			}

			Position = (Vector3) stream.ReceiveNext();
			Rotation = (Quaternion) stream.ReceiveNext();
			anim.SetInteger ("Walk",(int)stream.ReceiveNext());
			anim.SetBool ("Jump",(bool)stream.ReceiveNext());
			anim.SetBool ("Reload",(bool)stream.ReceiveNext());

		}
	}
}
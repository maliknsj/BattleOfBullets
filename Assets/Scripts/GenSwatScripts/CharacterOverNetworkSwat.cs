using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOverNetworkSwat : Photon.MonoBehaviour {
	Vector3 Position = Vector3.zero;
	Quaternion Rotation = Quaternion.identity;
	Animator anim;
	GameObject MeshCleaner;

	bool FirstUpdate = false;
	public string PLayerName;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		MeshCleaner = transform.Find ("genSWATPrefab").gameObject;
		PLayerName = PhotonNetwork.player.name;
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			//Do Nothing
			transform.Find("GunCamera").gameObject.SetActive(true);
			MeshCleaner.transform.Find ("genSWAT_LOD0").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("genSWAT_LOD1").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("genSWAT_LOD2").gameObject.SetActive (false);
			MeshCleaner.transform.Find ("genSWAT_Reference").gameObject.SetActive (false);
		}
		else {
			transform.Find("GunCamera").gameObject.SetActive(false);
			MeshCleaner.transform.Find ("genSWAT_LOD0").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("genSWAT_LOD1").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("genSWAT_LOD2").gameObject.SetActive (true);
			MeshCleaner.transform.Find ("genSWAT_Reference").gameObject.SetActive (true);
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
			stream.SendNext (anim.GetBool ("Death"));

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
			anim.SetBool ("Death", (bool)stream.ReceiveNext ());

		}
	}
}
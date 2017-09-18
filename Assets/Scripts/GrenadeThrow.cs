using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {
	GameObject GunCamera;

	// Use this for initialization
	void Start () {
		GunCamera = transform.Find ("GunCamera").gameObject;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			// hide gun to throw grenade
			if (transform.name == "Amanda(Clone)") {
				GunCamera.transform.Find ("FPS_m16_01").gameObject.SetActive (false);
			}
		}


		if (Input.GetKeyUp (KeyCode.G)) {
			//Show Gun
			if (transform.name == "Amanda(Clone)") {
				GunCamera.transform.Find ("FPS_m16_01").gameObject.SetActive (true);
			}

			//throw gernade
			GunFirePoint GFP = gameObject.GetComponentInChildren<GunFirePoint> ();

			GameObject Grenade = (GameObject) PhotonNetwork.Instantiate ("grenade",GFP.transform.position, GFP.transform.rotation, 0);
			Grenade.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 500);

		}
	}
}

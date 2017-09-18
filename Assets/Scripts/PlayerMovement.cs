using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	
	Vector3 newDestination = Vector3.zero;
	Animator anim;
	public GameObject BulletHoleParent;
	CharacterController charactercontroller;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		charactercontroller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		newDestination = transform.rotation * new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		if (newDestination.magnitude > 1f) {
			newDestination = newDestination.normalized;
		}

		anim.SetInteger ("Walk",(int) Input.GetAxis("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("Jump", true);
		} 
		if (Input.GetKeyDown (KeyCode.R)) {
			anim.SetBool ("Reload", true);
		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetInteger ("Walk", (int)Input.GetAxis ("Vertical"));
			anim.SetInteger ("Run", 1);
		}

		else {
			anim.SetBool ("Jump", false);
			anim.SetBool ("Reload", false);
			anim.SetInteger ("Run", 0);
		}

		if (Input.GetKeyUp (KeyCode.F)) {
			GunFirePoint GFP = gameObject.GetComponentInChildren<GunFirePoint> ();
			GameObject FlashBang = (GameObject) PhotonNetwork.Instantiate ("FlashBang",GFP.transform.position, GFP.transform.rotation, 0);
			//FlashBang.GetComponent<Rigidbody> ().AddRelativeForce (0, UpwardForce, ForwardForce, ForceMode.Impulse);
		}

	}

	void FixedUpdate(){
		charactercontroller.SimpleMove (newDestination);
	}
}
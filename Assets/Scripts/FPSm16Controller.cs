﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSm16Controller : MonoBehaviour {
	private Animator anim;
	public bool isreloading = false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void Plyyyy(){
		isreloading = true;
		anim.Play ("Reload");
		Invoke ("SetIsReloadingToFalse", 4f);
	}

	void SetIsReloadingToFalse(){
		isreloading = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("ShootFire");
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Plyyyy ();
		}

		if (Input.GetKey (KeyCode.W)) {
			anim.SetFloat ("Walk",Input.GetAxis("Vertical"));
//			anim.Play ("M16_walking");
		}

		if ((Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift))) {
			anim.SetFloat ("Walk",Input.GetAxis("Vertical"));
			anim.SetFloat ("Run", 1);
		}

		else if(!isreloading){
			anim.SetFloat ("Run", 0);
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
		}

	}
}

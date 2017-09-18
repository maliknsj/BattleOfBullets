using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SpringBreath : MonoBehaviour {
	float Stamina = 5;
	float MaxStamina = 5;
	FirstPersonController FPS;
	bool isRunning = false;
	LocalSounds LS;

	// Use this for initialization
	void Start () { 
		FPS = transform.GetComponent<FirstPersonController> ();	
		LS = transform.GetComponent<LocalSounds> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isRunning = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			isRunning = false;
		}

		if (isRunning) {
			Stamina -= Time.deltaTime;
			if (Stamina < 0) {
				Stamina = 0;
				FPS.m_RunSpeed = 4;
				LS.SprintBreath ();
//				LS.SprintBreath ();
				//StartCoroutine (Wait ());
				Debug.Log ("Daz Daz Stamina Khatam");

			}
		} 
		else if (Stamina < MaxStamina) {
			Debug.Log ("Daz Daz Stamina Aea");
			FPS.m_RunSpeed = 7;
			Stamina += Time.deltaTime;
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (3);
	}
}

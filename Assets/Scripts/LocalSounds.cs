using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSounds : MonoBehaviour {
	public AudioClip GrenadeSound;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GrenadeSounds(){
		transform.GetComponent<AudioSource> ().PlayOneShot (GrenadeSound);
	//	Camera.main.GetComponent<AudioSource> ().PlayOneShot (Resources.Load("Sounds/IN game Sounds/Noise") as AudioClip);
	}

	public void SprintBreath(){
		transform.GetComponent<AudioSource>().PlayOneShot (Resources.Load ("Sounds/IN game Sounds/breathLoop1") as AudioClip);

	}
}
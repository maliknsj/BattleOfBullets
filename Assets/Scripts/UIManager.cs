using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	AudioSource source;

	void Start(){
		source = Camera.main.GetComponent<AudioSource> ();	
		AudioClip sound;
	}

	public void Play(){
		Application.LoadLevel (2);
	}

	public void Quit(){
		Application.Quit ();
	}

	public void Heros(){
		Application.LoadLevel (1);
	}

	public void JoinRoom(){
		Application.LoadLevel (1);
	}

	public void ButtonHoverSound(AudioClip Sound){
		source.PlayOneShot (Sound);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectForward : MonoBehaviour {
	public static string HeroName;
	AudioSource source;
	public GameObject LoadingUI;

	void Start(){
		source = Camera.main.GetComponent<AudioSource> ();
	}

	public void GetName(){
	//	PlayerName = PlayerNameInputField.text.ToString();
	//	Debug.Log ("player name is " + PlayerName);
	//	PhotonNetwork.player.name = PlayerName;
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			HeroName = "Amanda";
		}
	}

	public void SplashScreen(){
		source.loop = true;
		source.clip = Resources.Load ("Sounds/IN game Sounds/ambience") as AudioClip;
		source.Play ();
		LoadingUI.SetActive (true);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelect : MonoBehaviour {
	public static string SelectedHero;
	RaycastHit hit;
	public GameObject UI;
	public InputField PlayerNameInputField;
	string PlayerName;
	public GameObject LoadingScreen;
	AudioSource source;

	void Start(){
		source = Camera.main.GetComponent<AudioSource> ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				SelectedHero = hit.collider.name;
				if (SelectedHero != null) {
					hit.collider.transform.Find ("Selection").gameObject.SetActive (true);
					UI.SetActive (true);
				}
			}
		}
	}

	public void SplashScreen(){
		source.loop = true;
		source.clip = Resources.Load ("Sounds/IN game Sounds/ambience") as AudioClip;
		source.Play ();


		LoadingScreen.SetActive (true);
		UI.SetActive (false);
	}

	public void ContinueUI(){
		Camera.main.GetComponent<AudioSource> ().PlayOneShot (Resources.Load("Sounds/IN game Sounds/ready") as AudioClip);
		UI.SetActive (false);
		Application.LoadLevel (2);
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadialSoundMenu : MonoBehaviour {
	AudioSource source;
	public AudioClip InTheBagSound;

	public List<Button> Buttons = new List<Button>();
	bool isOpen  = false;
	float Dsitance = 180;
	Vector2[] ButtonPos;

	// Use this for initialization
	void Start () {
//		Buttons = this.GetComponentsInChildren<Button> (true).Where (x => x.transform.parent != transform.parent).ToList ();	

//		this.GetComponent<Button> ().onClick.AddListener (() => {
//			OpenButtons ();
//		});

		source = Camera.main.GetComponent<AudioSource> ();

		ButtonPos = new Vector2[Buttons.Count];
	}

	public void OpenButtons(){
		Debug.Log ("Chu  thaaaaaae");
		isOpen = !isOpen;
		float angle = 90 / (Buttons.Count - 1) * Mathf.Deg2Rad;

		for (int i = 0; i < Buttons.Count; i++) {
			if (isOpen) {
				float xPos = Mathf.Cos (angle * i) * Dsitance;
				float yPos = Mathf.Sin (angle * i) * Dsitance;

				Buttons [i].gameObject.SetActive (true);

				ButtonPos[i] = new Vector2 (this.transform.position.x + xPos, this.transform.position.y + yPos);

			}
			else {
				ButtonPos [i] = this.transform.position;
				Buttons [i].gameObject.SetActive (false);
			}
		}

		StartCoroutine (ButtonsAnim());
	}


	IEnumerator ButtonsAnim(){
		foreach (Button b in Buttons) {
			b.gameObject.SetActive (true);
		}
		int loops = 0;
		while (loops <= Dsitance / 5) {
			yield return new WaitForSeconds (0.01f);
			for (int i = 0; i < Buttons.Count; i++) {
				Color c = Buttons [i].gameObject.GetComponent<Image> ().color;
				if (isOpen) {
					c.a = Mathf.Lerp (c.a, 1, 1 * Time.deltaTime);
				}
				else {
					c.a = Mathf.Lerp (c.a, 0, 1 * Time.deltaTime);
				}
				Buttons [i].gameObject.GetComponent<Image> ().color = c;
				Buttons [i].gameObject.transform.position = Vector2.Lerp (Buttons [i].gameObject.transform.position, ButtonPos [i], 1 * Time.deltaTime);
					
			}
			loops++;
		}
		if (!isOpen) {
			foreach (Button b in Buttons) {
				b.gameObject.SetActive (false);
			}
		}
	}
		
	public void InTheBag(){
		Debug.Log ("Chuuu Dazzzzzzzzzz 2");
		source.PlayOneShot (InTheBagSound);
	}
}

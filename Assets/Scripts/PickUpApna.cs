using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpApna : MonoBehaviour {

	public float raycastLength = 20f;
	Text textforPickUp;

	void Start(){
		textforPickUp = GameObject.Find ("PickUpText").GetComponent<Text>();
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit,raycastLength))
		{
			if (hit.collider.tag == "PickUp") {
				//		Debug.Log("Found item!" + hit.collider.name);
				textforPickUp.text = "Press E to Destroy " + hit.collider.name;

				if (Input.GetKeyDown ("e")) {
					Destroy (hit.collider.gameObject);
				}
			}
			else {
				textforPickUp.text = "";
			}
		}
	}

}

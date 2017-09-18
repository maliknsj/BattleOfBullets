using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLine : MonoBehaviour {
	
	public float time = 0.5f;
	PhotonView photonview;

	void Start(){
		photonview = GetComponent<PhotonView> ();
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			
			if (photonview != null && photonview.instantiationId != 0) {
				PhotonNetwork.Destroy (gameObject);
			} 
			else {
				Destroy (gameObject);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour {
	
	[Header("Spot Lights of All Heros")]
	public GameObject Amanda;
	public GameObject GenSwat;
	public GameObject SwatNorth;
	public GameObject USSoldier;

	public void AmandaLightOn(){
		Amanda.transform.Find ("Spotlight").GetComponent<Light> ().intensity = 479.1f;
		//Amanda.GetComponent<Animator> ().Play ("Ready");
	}

	public void AllFalse(){
		Amanda.transform.Find ("Spotlight").GetComponent<Light> ().intensity = 0;
		Amanda.GetComponent<Animator> ().Play ("idle");


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashOverNetwork : MonoBehaviour {

	public ParticleSystem FlashNetwork;

	[PunRPC]
	void ActiveMuzzleFlashNetwork(){
//		MuzzleFlashEffectNetwork
		Debug.Log("Muzzle Flash Network");
		FlashNetwork.Play();
	}
}

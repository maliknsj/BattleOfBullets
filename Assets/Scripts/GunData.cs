using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunData : MonoBehaviour {
	public int ExtraAmmo = 90;
	public int Bullets = 30;
	Text BulletsText;
	Text MagzieText;
	public string PLayerName;

	// Use this for initialization
	void Start () {
		BulletsText = GameObject.Find ("BulletText").GetComponent<Text>();	
		MagzieText = GameObject.Find ("MagzineText").GetComponent<Text>();
		PLayerName = PhotonNetwork.playerName;
	}
	
	// Update is called once per frame
	void Update () {
		BulletsText.text = Bullets.ToString ();
		MagzieText.text = ExtraAmmo.ToString ();
	}

	public void DecreaseBullet(){
		Bullets -= 1;
	}

	public void ReloadGun(){
		int TempAmmo = 30 - Bullets;
		Bullets = 30;
		ExtraAmmo -= TempAmmo;
	}
}
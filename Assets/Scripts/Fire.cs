using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour {
	
	float fireRate = 0.1f;
	float nextFire;
	GunData GD;
	RaycastHit hit;
	VisualEffectsManager visual;
	public ParticleSystem partsaksdma;
	public string GunName;
	AudioSource source;
	FPSm16Controller FireGunAnim;
	ScoreCounterForNetwork ScoreCounter;
	Text DeathText;
	//saving scores
	PlayerScoreSaver PSS;
	float var;

	// Use this for initialization
	void Start () {
		GD = transform.GetComponent<GunData> ();
		visual = GameObject.FindObjectOfType<VisualEffectsManager> ();
		source = transform.GetComponent<AudioSource> ();
		FireGunAnim = gameObject.GetComponentInChildren<FPSm16Controller> ();
		ScoreCounter = transform.GetComponent<ScoreCounterForNetwork> ();
		PSS = GameObject.FindObjectOfType<PlayerScoreSaver>();
		DeathText = GameObject.Find ("DeathText").GetComponent<Text> ();;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			
			if (Input.GetMouseButton (0)) {
				nextFire = Time.time + fireRate;
				if (GD.Bullets > 0) {
					if (FireGunAnim.isreloading == true)
						return;
					if (FireGunAnim.isreloading != true) {
						GD.DecreaseBullet ();
						GetComponent<PhotonView> ().RPC ("ActiveMuzzleFlashNetwork", PhotonTargets.All);
						DoFire ();
					}
				}
				else if (GD.Bullets <= 0 && !(GD.ExtraAmmo <= 0)) {
					FireGunAnim.Plyyyy ();
					GD.ReloadGun ();
					//GD.Bullets = 30;
					//GD.ExtraAmmo -= 30;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			if (GD.Bullets != 30 && !(GD.ExtraAmmo <= 0)) {
				GD.ReloadGun ();
			}
		}
	}

	void DoFire(){
		Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);

		if (GunName == "ak47") {
			source.PlayOneShot (Resources.Load ("Sounds/Guns Sounds/ak47") as AudioClip);
			partsaksdma.Play ();
		}
		if (GunName == "g3") {
			source.PlayOneShot (Resources.Load ("Sounds/Guns Sounds/g3") as AudioClip);
			partsaksdma.Play ();
		}

		if(Physics.Raycast(ray,out hit)){
			float damage = Random.Range(0,25);
			Health h = hit.collider.GetComponent<Health> ();
			GunData G = hit.collider.GetComponent<GunData> ();

			if (h.health <= damage) {
				string sms = PhotonNetwork.player.name + " Killed " + G.PLayerName;
				GetComponent<PhotonView> ().RPC ("DeathTextFn",PhotonTargets.All,sms);
				ScoreCounter.Kills++;
				PSS.SaveKills = ScoreCounter.Kills;
			}
			h.GetComponent<PhotonView> ().RPC ("Damage", PhotonTargets.AllBuffered,damage);
		}
	}


	[PunRPC]
	void DeathTextFn(string sms){
		DeathText.text = sms;
	}

}

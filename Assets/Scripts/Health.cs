using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public float health = 100;
	public float Armor = 100;
	Image HealthImage;
	Image ArmorImage;
	PhotonView PV;
	Animator anim;
	public float Healingspeed = 0f;

	void Start(){
		HealthImage = GameObject.Find("HealthUI").GetComponent<Image>();
		ArmorImage = GameObject.Find("ArmorUI").GetComponent<Image>();
		PV = transform.GetComponent<PhotonView> ();
		anim = transform.GetComponent<Animator> ();
	}

	void Update(){
		if (PV.isMine) {
			HealthImage.rectTransform.sizeDelta = new Vector2 (health, 100);
			ArmorImage.rectTransform.sizeDelta = new Vector2 (Armor, 100);
		}
		if (health >= 100) {
			Healingspeed = 0;
		}

		if (health < 100) {
			Healingspeed = 4;
			health += Healingspeed * Time.deltaTime;
		}
	}

	[PunRPC]
	public void Damage(float damage){
		health = health - damage;
		Armor -= damage / 2;
		if (health <= 0) {
			anim.SetBool ("Death",true);
			StartCoroutine(Wait());
			if (GetComponent<PhotonView> ().instantiationId == 0) {
				Destroy (gameObject);
			} else {
				if (GetComponent<PhotonView> ().isMine) {
					if (gameObject.tag == "Player") {
						NetworkManager NM = GameObject.FindObjectOfType<NetworkManager>();
						NM.AloneCamera.gameObject.SetActive (true);
						NM.respawnTIme = 5.0f;
					}
					PhotonNetwork.Destroy (gameObject);
				}
			}
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (4);
	}
}
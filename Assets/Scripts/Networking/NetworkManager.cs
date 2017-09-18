using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {
	
	[Header("Panel for ScoreBoard")]
	[Space]
	public GameObject ScoreBoardPanelParent;
	public GameObject UIPrefab;

	[Space(10)]

	[Header("UI Elements")]
	[Space]
	public Text Bullets;
	public Text NetworkStatetext;

	[Space(10)]
	public float respawnTIme = 0;
	public Camera AloneCamera;

	[Space(10)]
	[Header("Player Attributes")]
	[Space]
	public Text PlayerName;
	public Text PlayerHealth;
	public Image PlayerAvatar;

	[Space(10)]
	[Header("Set Offline Mode for testing purposes")]
	[Space]
	public bool offlinemode = false;

	Health h;
	bool Connecting = false;

	void Start () {
		Connect();		
		h = FindObjectOfType<Health> ();
	}

	void Update(){
		if (Input.GetKey (KeyCode.Tab)) {
			//Destroy All Score Created Before
			foreach (Transform child in ScoreBoardPanelParent.transform.Find("ScoreBoardUnit").transform) {
				GameObject.Destroy (child.gameObject);
			}
			foreach (PhotonPlayer player in PhotonNetwork.playerList) {
				GameObject GOB = (GameObject) Instantiate (UIPrefab);
				GOB.transform.SetParent (ScoreBoardPanelParent.transform.Find("ScoreBoardUnit").transform);
				string Kills = (string)player.customProperties ["Kills"];
				string Deaths = (string)player.customProperties ["Deaths"];
				string Assists = (string)player.customProperties ["Assists"];
				GOB.transform.Find ("NameHeader").GetComponent<Text> ().text = player.name;
				GOB.transform.Find ("KillsHeader").GetComponent<Text> ().text = Kills;
				GOB.transform.Find ("DeathHeader").GetComponent<Text> ().text = Deaths;
				GOB.transform.Find ("AssistHeader").GetComponent<Text> ().text = Assists;
			}
//			int NumbrofPlayers = (int)PhotonNetwork.countOfPlayers;
			ScoreBoardPanelParent.GetComponent<CanvasGroup> ().alpha = 1;
		}

		else {
			ScoreBoardPanelParent.GetComponent<CanvasGroup> ().alpha = 0;
		}

		// Player Respawn is handling here
		if (respawnTIme > 0) {
			respawnTIme -= Time.deltaTime;

			if (respawnTIme <= 0) {
				SpawnPlayer ();
			}
		}

		//Set Player Name in UI text
		PlayerName.text = PhotonNetwork.player.name;

		//Checking Health
		PlayerHealth.text = (int) Mathf.Abs(h.health) + "";
		if (h.health > 70) {
			PlayerHealth.color = Color.green;
		}
		else if (h.health < 70 && h.health > 40) {
			PlayerHealth.color = Color.yellow;
		}
		else if (h.health < 40 && h.health > 0) {
			PlayerHealth.color = Color.red;
		}



	}

	void Connect(){
		if (offlinemode) {
			PhotonNetwork.offlineMode = true;
			OnJoinedLobby ();
		}
		else {
			//SpotsToSpawn = GameObject.FindObjectsOfType<SpawnPointPlayer> ();
			PhotonNetwork.ConnectUsingSettings ("Version 01");
		}
	}

	void PlayerSpawnSMS(string sms){
		GetComponent<PhotonView> ().RPC ("SMS_RPC",PhotonTargets.AllBuffered,sms);
	}

	void OnGUI(){
		if(PhotonNetwork.connected != true){
			NetworkStatetext.text = PhotonNetwork.connectionStateDetailed.ToString();
		}
		if (PhotonNetwork.connected == true) {
			NetworkStatetext.GetComponent<CanvasGroup> ().alpha = 0;
		}
	}

	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom ( "Daz Daz Room" );
	}

	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
		Connecting = true;
		SpawnPlayer ();
	}

	void SpawnPlayer(){
		//PlayerSpawnSMS ("Spawing Player " + PhotonNetwork.player.name);
//		GameObject playerobject =(GameObject) PhotonNetwork.Instantiate (HeroSelect.SelectedHero,new Vector3(653.1442f,53.852f,703.296f),Quaternion.identity, 0);
		GameObject playerobject =(GameObject) PhotonNetwork.Instantiate (HeroSelectForward.HeroName,transform.position,Quaternion.identity, 0);

		if(HeroSelect.SelectedHero == "genSWAT"){
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<PickUpApna> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<SpringBreath> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if (HeroSelect.SelectedHero == "Amanda") {
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<PickUpApna> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<SpringBreath> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if (HeroSelect.SelectedHero == "USSOLDIER") {
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GrenadeThrow> ().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<PickUpApna> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			playerobject.GetComponent<SpringBreath> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}

		if(HeroSelect.SelectedHero == "genSWAT North"){
			playerobject.GetComponent<PlayerMovement> ().enabled = true;
			playerobject.GetComponent<AudioSource> ().enabled = true;
			playerobject.GetComponent<FirstPersonController>().enabled = true;
			playerobject.GetComponent<Fire>().enabled = true;
			playerobject.GetComponent<GunData> ().enabled = true;
			playerobject.GetComponent<PickUpApna> ().enabled = true;
			playerobject.GetComponent<BloodDamage> ().enabled = true;
			playerobject.GetComponent<SpringBreath> ().enabled = true;
			playerobject.GetComponent<LocalSounds> ().enabled = true;
			playerobject.GetComponent<ScoreCounterForNetwork> ().enabled = true;
			AloneCamera.gameObject.SetActive (false);
		}


	}
}
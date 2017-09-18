using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounterForNetwork : MonoBehaviour {
	public int Kills;
	public int Deaths;
	public int Assists;
	PlayerScoreSaver PSSForLoad;

	// Use this for initialization
	void Start () {
		PSSForLoad = GameObject.FindObjectOfType<PlayerScoreSaver>();	
		Kills = PSSForLoad.SaveKills;
		Deaths = PSSForLoad.SaveDeaths;
	}
	
	// Update is called once per frame
	void Update () {
		ExitGames.Client.Photon.Hashtable PLayerID = new ExitGames.Client.Photon.Hashtable ();
		PLayerID.Add ("Kills", Kills.ToString());
		PLayerID.Add ("Deaths", Deaths.ToString());
		PLayerID.Add ("Assists", Assists.ToString());
		PhotonNetwork.player.SetCustomProperties (PLayerID);
	}
}

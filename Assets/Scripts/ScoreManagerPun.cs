using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerPun : MonoBehaviour {

	Dictionary<string,Dictionary<string,int>> PlayerScores;

	// Use this for initialization
	void Start () {
		//PlayerScores [PhotonNetwork.player.name] = new Dictionary<string, int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Init(){ 
		if (PlayerScores != null) {
			return;
		}
		PlayerScores = new Dictionary<string, Dictionary<string, int>> ();
	}

	public int GetKills(string PlayerName, string Type){
		Init ();

		if (PlayerScores.ContainsKey (PlayerName) == false) {
			return 0;
		}

		if (PlayerScores [PlayerName].ContainsKey (Type) == false) {
			return 0;
		}

		return PlayerScores [PlayerName] [Type];
	}

	public void SetKills(string PlayerName, string Type, int Kills){
		Init ();

		if (PlayerScores.ContainsKey (PlayerName) == false) {
			PlayerScores [PlayerName] = new Dictionary<string, int> ();
		}

		PlayerScores [PlayerName] [Type] = Kills;

	}

	public void ChangeKills(string PlayerName, string Type, int Kills){
		Init ();

		int CurrentScore = GetKills (PlayerName, Type);
		SetKills (PlayerName, Type, CurrentScore + Kills);


	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooseButtons : MonoBehaviour {
	[Header("Assigns Panels of all Maps")]
	public Transform MilitryPackPanel;
	public Transform ForestPanel;
	public Transform DesertPanel;
	public Transform TBDPanel;

	[Space(10)]

	[Header("Assign GO Button")]
	public Transform GO;

	[Space(10)]
	[Header("Selected Map")]
	public static string SelectedMap;

	bool isTrue = false;
	int check = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MilitryPackClick(){
		ForestPanel.GetComponent<Animator> ().SetBool ("Run",false);

		if (check == 1) {
			check++;
			isTrue = true;
			GO.gameObject.SetActive (true);
			SelectedMap = "Militry";
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			check = 1;
			isTrue = false;
			GO.gameObject.SetActive (false);
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void MilitryPackHover(){
		if (isTrue == false) {
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
	}

	public void MilitryPackUnHover(){
		if (!isTrue) {
			MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void ForestClick(){
		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run",false);

		if (check == 1) {
			check++;
			isTrue = true;
			SelectedMap = "Forest";
			GO.gameObject.SetActive (true);
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
		else {
			check = 1;
			isTrue = false;
			GO.gameObject.SetActive (false);
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}

	public void ForestHover(){
		if (isTrue == false) {
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", true);
		}
	}

	public void ForestUnHover(){
		if (!isTrue) {
			ForestPanel.GetComponent<Animator> ().SetBool ("Run", false);
		}
	}
}
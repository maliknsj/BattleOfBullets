using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChooseButtons : MonoBehaviour {
	public Transform MapDetailsParent;

	public Transform MilitryPackPanel;
	public Transform ForestPanel;
	public Transform DesertPanel;
	public Transform TBDPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MilitryPackClick(){
		//MilitryPackPanel.GetComponent<RectTransform> ().anchorMax = new Vector2 (1,1);

		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run",true);
	}

	public void ForestClick(){
		MilitryPackPanel.GetComponent<Animator> ().SetBool ("Run",false);
	}

}
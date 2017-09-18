using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI2Manager : MonoBehaviour {

	public Menu mmenu;

	// Use this for initialization
	void Start () {
		VisibleMenu (mmenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VisibleMenu(Menu menu){
		if (mmenu != null) {
			mmenu.isOpen = false;
		}
		mmenu = menu;
		mmenu.isOpen = true;
	}
}

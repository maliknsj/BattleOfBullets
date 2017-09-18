using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	Animator anim;
	CanvasGroup CG;

	public bool isOpen{
		get{ return anim.GetBool("IsOpen");}
		set{ anim.SetBool ("IsOpen", value); }
	}

	void Awake(){
		anim = GetComponent<Animator> ();
		CG = GetComponent<CanvasGroup> ();

		var Rect = GetComponent<RectTransform> ();
		Rect.offsetMax = Rect.offsetMin = new Vector2 (0,0);

	}

	void Update(){
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Empty")) {
			CG.blocksRaycasts = CG.blocksRaycasts = false;

		}
		else {
			CG.blocksRaycasts = CG.interactable = true;
		}
	}
}

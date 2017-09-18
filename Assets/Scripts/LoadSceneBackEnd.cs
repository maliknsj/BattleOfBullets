using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneBackEnd : MonoBehaviour {
	public GameObject LoadingCircle;
	public Text LoadingPercent;

	// Use this for initialization
	void Start () {
		StartCoroutine (LoadScene());
	}

	IEnumerator LoadScene(){
		yield return new WaitForSeconds (3);

		AsyncOperation asyncopp = Application.LoadLevelAsync (3);
		LoadingPercent.text = asyncopp.progress.ToString();
		LoadingCircle.GetComponent<Image> ().fillAmount = asyncopp.progress / 100;


		while (!asyncopp.isDone) {
			yield return null;
		}
	}
}	
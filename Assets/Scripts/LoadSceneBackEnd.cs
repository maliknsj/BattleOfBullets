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

		AsyncOperation asyncopp = Application.LoadLevelAsync (MapChooseButtons.SelectedMap);


		while (!asyncopp.isDone) {

			if (asyncopp.progress >= 0.89) {
				asyncopp.allowSceneActivation = true;
			}
			float progress = Mathf.Clamp01(asyncopp.progress / 0.9f);
			LoadingPercent.text = ((int)(progress * 100)).ToString();
			LoadingCircle.GetComponent<Image> ().fillAmount = progress;
			yield return null;
		}
	}
}
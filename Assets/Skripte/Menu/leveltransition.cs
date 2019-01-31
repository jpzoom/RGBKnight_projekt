using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltransition : MonoBehaviour {

	private coinMaster coinmaster;

	void Start() {
		coinmaster = GameObject.FindGameObjectWithTag ("coinmaster").GetComponent<coinMaster>();
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag ("Player") && !col.isTrigger) {
			StartCoroutine ("EndLevel");
		}
	}

	IEnumerator EndLevel() {
		float fadeTime = GameObject.Find ("fadeoutholder").GetComponent<fadeouthandler> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("game_over", LoadSceneMode.Single);
	}
}

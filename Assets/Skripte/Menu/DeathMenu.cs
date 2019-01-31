using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class DeathMenu : MonoBehaviour {
	public bool check;
	public Vitez vitez;

	void Update() {
		check = true;
		if (vitez.currentHealth <= 0) {
			Time.timeScale = 0;
			if (Input.GetButtonDown ("Pause")) {
				return;
			}
		}
	}
	public void RestartGame() {
		Scene currentscene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentscene.name);
		Time.timeScale = 1;
	}

	public void QuitToMainMenu() {
		StartCoroutine ("mainm");
	}

	IEnumerator mainm() {
		Time.timeScale = 1;
		yield return new WaitForSeconds (0.01f);
		SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
	}
}

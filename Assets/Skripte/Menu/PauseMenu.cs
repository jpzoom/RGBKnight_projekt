using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public bool paused = false;


	void Start () {
		PauseUI.SetActive (false);
	}

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}// sprjecava horizontal input u meniu


		if(!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}

	}



	public void Resume () {
		StartCoroutine ("resumeWait");
		//paused = false;
	}

	public void Restart () {
		//Scene currentscene = SceneManager.GetActiveScene ();
		//SceneManager.LoadScene (currentscene.name);

		StartCoroutine ("restartWait");
	}

	public void MainMenu () {
		SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
	}

	public void Quit () {
		Application.Quit ();
	}
		
	IEnumerator resumeWait() {
		yield return new WaitForSecondsRealtime (0.3f);
		paused = false;
	}

	IEnumerator restartWait() {
		yield return new WaitForSecondsRealtime (0.3f);
		Scene currentscene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentscene.name);
	}


}

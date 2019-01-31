using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvermenu : MonoBehaviour {

	public void restartGame () {
		SceneManager.LoadScene ("testing_ground", LoadSceneMode.Single);
	}

	public void mainMenu () {
		SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
	}
		
}

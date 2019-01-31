using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenu;
	public Button buttOptions;

	void Start () {
		buttOptions.interactable = false;
	}
	public void newGame () {
		SceneManager.LoadScene ("testing_ground", LoadSceneMode.Single);
			}
	public void QuitPrompt () {
		Application.Quit ();		
	}

}

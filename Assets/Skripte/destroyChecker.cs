using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyChecker : MonoBehaviour {

	public WizardAI wizard;
	public AudioSource sound;

	void Start() {
		wizard = gameObject.GetComponent<WizardAI> ();
	}

	void Update () {
		
		if (wizard == null) {
			
			sound.Play ();
		}
	}

}
		
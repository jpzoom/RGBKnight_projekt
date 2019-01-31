using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBox : MonoBehaviour {

	public WizardAI wizAI;
	public bool isLeft = false;

	void Start() {
		//wizAI = gameObject.GetComponentInParent<WizardAI>();
	
	}

/*	void Awake () {
		
		wizAI = gameObject.GetComponentInParent<WizardAI> ();
	
	}*/

	void OnTriggerStay2D(Collider2D col) {
	
		if (col.CompareTag ("Player")) {
			
			if (isLeft) {

				wizAI.attack(true);
				//wizAI.anim.SetTrigger ("Acounter");
				//wizAI.acount = (true);

			} else {
				//wizAI.anim.ResetTrigger ("Acounter");
				wizAI.attack (false);
				//wizAI.acount = false;
			}

		}

	}

}

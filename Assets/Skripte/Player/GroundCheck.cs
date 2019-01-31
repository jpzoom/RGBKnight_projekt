using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private Vitez vitez;

	void Start() {
		vitez = gameObject.GetComponentInParent<Vitez>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (!col.isTrigger)
			vitez.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		vitez.grounded = false;
	}
		

}

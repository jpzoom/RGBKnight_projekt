using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouceBack : MonoBehaviour {

	private Vitez player; // access health
	public float knockBack = 80;
	public int xback = 15;
	//private int i = 0;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Vitez> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player") && !col.isTrigger) {
			if (player.invincible == false) {
				//invincible = true;
				StartCoroutine (player.knockBack (0.001f, knockBack, player.transform.position, xback));
				//i++;
				//Invoke("resetInvincible", 1);
			}
		}
	}

	/*void resetInvincible() {
		Debug.Log ("Invincible = " +invincible);
		invincible = false;
	}*/

	void OnTriggerExit2d(Collider2D col) {
		//i = 0;
	}


}


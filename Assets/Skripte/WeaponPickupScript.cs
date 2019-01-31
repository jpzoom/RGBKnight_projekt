using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour {

	public Vitez vitez;
	public GameObject koplje;
	public AudioSource asource; // objekt sa zvučnom datotekom

	void Start() {
		koplje = GameObject.FindGameObjectWithTag ("Spear");
	}

	void OnTriggerEnter2D (Collider2D other) {
		vitez.counter += 1;
		asource.Play (); // zvučna datoteka se uključuje
		koplje.gameObject.SetActive (false);
	}
}

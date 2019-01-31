using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnpitscript : MonoBehaviour {

	private GameObject player;
	public Transform respawnPoint;
	public GameObject respawnPortal;
	public Vitez vitez;
	public GameObject sound;
	public GameObject deathsound;

	void Start () {
		deathsound = GameObject.FindGameObjectWithTag ("Deathsound");
		deathsound.gameObject.SetActive (false);
		sound = GameObject.FindGameObjectWithTag ("Soundofportal");
		sound.gameObject.SetActive (false);
		respawnPortal = GameObject.FindGameObjectWithTag ("respawnPortal");
		respawnPortal.gameObject.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.name == "Vitez") {
			StartCoroutine ("Respawn");
		}
	}
		
	IEnumerator Respawn() {
		player.GetComponent<Vitez>().enabled = false;
		deathsound.gameObject.SetActive (true);
		yield return new WaitForSeconds (2f); // cekanje za micanje kamere
		sound.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		//yield return new WaitForSeconds (1.5f); // cekanje za portal
		respawnPortal.gameObject.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		player.transform.position = respawnPoint.transform.position;
		//yield return new WaitForSeconds (0.2f); 
		player.GetComponent<Vitez>().enabled = true;
		deathsound.gameObject.SetActive (false);
		yield return new WaitForSeconds (3);
		sound.gameObject.SetActive (false);
		respawnPortal.gameObject.SetActive (false);


	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batfixAI : MonoBehaviour {

	public int maxHP = 100;
	public int currentHP;

	//	public Rigidbody2D rb2d;
	//	public float velocity = 1f;

	public GameObject deathEffect;
	public bool checker = false;
	public GameObject deathSound;

	//sinusoida
	public float visinaValaX = 114f;
	public float visinaValaY = 5.0f;
	public float brValovaX = 1.0f;
	public float brValovaY = 5.0f;
	public float brojac;
	public float brojZaZbrajanje = 0.5f;
	public float lokacijaX = 114;
	public float lokacijaY = 44;

	void Start () {
		currentHP = maxHP;
		deathSound = GameObject.FindGameObjectWithTag ("deathexplosion");
		deathEffect = GameObject.FindGameObjectWithTag ("deathexplosion");
	}

	void Update () {

		brojac += brojZaZbrajanje;
		float x = visinaValaX * Mathf.Cos (brValovaX*brojac)+lokacijaX;
		float y = visinaValaY * Mathf.Sin (brValovaY * brojac)+lokacijaY;
		transform.localPosition = new Vector3 (x,y,0);

		if (currentHP <= 0) {
			if (checker==false) {
				Instantiate (deathEffect, transform.position, transform.rotation);
				checker = true;
			}
			StartCoroutine ("death");
		}
	}

	public void Damage (int damage) {
		currentHP -= damage;
	}

	IEnumerator death () {
		gameObject.GetComponent<Animation> ().Play ("enemy_dmg");
		deathSound.GetComponent<AudioSource> ().Play ();
		yield return new WaitForSeconds (0.01f);
		gameObject.SetActive (false);
		Destroy (gameObject);	
	}

}


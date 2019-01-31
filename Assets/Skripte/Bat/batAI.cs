using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batAI : MonoBehaviour {

	public int maxHP = 100;
	public int currentHP;

//	public Rigidbody2D rb2d;
//	public float velocity = 1f;

	public GameObject deathEffect;
	public bool checker = false;
	public GameObject deathSound;
	private coinMaster coinmaster;

	//sinusoida
	public float lokacijaX = 10.0f;
	public float lokacijaY = 10;
	public float iznosY = 5.0f;
	public float brojZaZbrojiti = 1.0f;
	public float visinaVala = 5;
	public float brojValova = 0.25f;


	void Start () {
		currentHP = maxHP;
		deathSound = GameObject.FindGameObjectWithTag ("deathexplosion");
		deathEffect = GameObject.FindGameObjectWithTag ("deathexplosion");
		coinmaster = GameObject.FindGameObjectWithTag ("coinmaster").GetComponent<coinMaster>();
	}

	void Update () {

		lokacijaX += brojZaZbrojiti;
		iznosY = visinaVala * Mathf.Sin (brojValova * lokacijaX) + lokacijaY;
		transform.localPosition = new Vector3 (-lokacijaX,iznosY,0);


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
		coinmaster.points = coinmaster.points + 15;
	}

}


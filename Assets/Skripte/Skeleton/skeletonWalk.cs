using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonWalk : MonoBehaviour {

	public Rigidbody2D rb2d;
	public float velocity = 1f;

	public int maxHP = 20;
	public int currentHP;

	public bool checker = false;
	public GameObject deathEffect;
	public GameObject deathSound;
	private coinMaster coinmaster;

	public Transform sightStart;
	public Transform sightEnd;
	public LayerMask detectWhat;

	public bool hasHit;

	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		currentHP = maxHP;
		deathSound = GameObject.FindGameObjectWithTag ("skeldeath");
		deathEffect = GameObject.FindGameObjectWithTag ("deathexplosion");
		coinmaster = GameObject.FindGameObjectWithTag ("coinmaster").GetComponent<coinMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (velocity, rb2d.velocity.y);

		hasHit = Physics2D.Linecast (sightStart.position, sightEnd.position, detectWhat);

		if (hasHit) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			velocity *= -1;
		}

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
		yield return new WaitForSeconds (0);
	 	gameObject.SetActive (false);
		Destroy (gameObject);
		coinmaster.points = coinmaster.points + 25;
	}

/*	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(sightStart.position, sightEnd.position);
	}*/
}

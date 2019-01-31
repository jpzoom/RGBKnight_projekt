using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAI : MonoBehaviour {

	//integers

	public int maxHP = 100;
	public int currentHP;

	public float shootInterval;
	public float fireballSpeed = 100;
	public float fireballTimer= 1.5f;

	public bool acount;
	public GameObject deathEffect;

	//references
	public GameObject fireball;
	public GameObject fireballtwo;
	private GameObject player;
	public Transform target;
	private coinMaster coinmaster;

	public Transform shootLeft;
	//public Transform shootRight;
	//Vector3 dir;

	public Animator anim;
	public GameObject destCheck;
	public AudioSource fireballSound;

	public bool turnRight = false;

	void Start() {
		
		currentHP = maxHP;
		destCheck = GameObject.FindGameObjectWithTag ("Destenemysound");
		deathEffect = GameObject.FindGameObjectWithTag ("deathexplosion");
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		coinmaster = GameObject.FindGameObjectWithTag ("coinmaster").GetComponent<coinMaster>();

			fireball = GameObject.FindGameObjectWithTag ("fireballRed");
			fireballtwo = GameObject.FindGameObjectWithTag ("fireballRedTwo");

	}

	void Update() {
		
		if (target.transform.position.x > transform.position.x) {

			transform.localScale = new Vector3 (-1, 1, 1);
			turnRight = true;

		}

		if (target.transform.position.x < transform.position.x) {

			transform.localScale = new Vector3 (1, 1, 1);
			turnRight = false;

		}

		if (currentHP <= 0) {
			StartCoroutine ("death");
		}
	}

	public void attack(bool attackingRight) {

		fireballTimer += Time.deltaTime;

		if (fireballTimer >= shootInterval) {
		
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			if (!turnRight) {
				anim.SetTrigger ("Acounter");
				GameObject fbClone;
				fireballSound.Play();
				fbClone = Instantiate (fireball, shootLeft.transform.position, shootLeft.transform.rotation) as GameObject;
				fbClone.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;

				fireballTimer = 0;
			}

			if (turnRight) {
				anim.SetTrigger ("Acounter");
				GameObject fbClone;
				fireballSound.Play();
				fbClone = Instantiate (fireballtwo, shootLeft.transform.position, shootLeft.transform.rotation) as GameObject;
				fbClone.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;
				Debug.Log ("Fireball two!!");
				fireballTimer = 0;
			}

		}
	}

	public void Damage (int damage) {
		currentHP -= damage;
		gameObject.GetComponent<Animation> ().Play ("enemy_dmg");
		gameObject.GetComponent<AudioSource> ().Play ();
	}

	IEnumerator death () {
		destCheck.GetComponent<AudioSource> ().Play ();
		gameObject.GetComponent<Animation> ().Play ("enemy_dmg");
		yield return new WaitForSeconds (0.3f);
		Instantiate (deathEffect, transform.position, transform.rotation);
		gameObject.SetActive (false);
		Destroy (gameObject, 3f);
		coinmaster.points = coinmaster.points + 75;
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitez : MonoBehaviour {

	// Use this for initialization
	public float maxSpeed = 150f;
	public float speed = 50f;
	public float jumpPower = 50f;

	//player stats
	public int currentHealth;
	public int maxHealth = 6;
	// ----

	public bool grounded;
	public bool canDoubleJump;
	public bool invincible;
	public int counter;

	public Rigidbody2D rb2d;
	private Animator anim; // Animator reference
	private Vitez vitez;
	public GameObject player;
	public PauseMenu menu;
	public DeathMenu deathMenu;
	private coinMaster coinmaster;
	public GameObject coinaudio;

	public AudioSource jumpsound;


	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		currentHealth = maxHealth;
		coinmaster = GameObject.FindGameObjectWithTag ("coinmaster").GetComponent<coinMaster>();
		coinaudio = GameObject.FindGameObjectWithTag ("coinsound");
	}

	// Update is called once per frame
	void Update () {

		anim.SetBool ("Groundedn", grounded);
		anim.SetFloat ("Walkspeed", Mathf.Abs(rb2d.velocity.x)); // Mathf.Abs sluzi u svrhu dobivanja uvijek pozitivnog broja
		anim.SetInteger ("Spearcounter", counter);
		//anim.SetBool ("Attack", attack);

		if (menu.paused != true && deathMenu.check !=true) {


			if (Input.GetAxisRaw ("Horizontal") < -0.1f) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}

			if (Input.GetAxisRaw ("Horizontal") > 0.1f) {
				transform.localScale = new Vector3 (1, 1, 1);
			}

			//prijasnji if-ovi sluze za okretanje lika lijevo/desno stiskom lijevo i desno

			if (Input.GetButtonDown ("Jump")) {   
				if (grounded) {
					rb2d.AddForce (Vector2.up * jumpPower);
					canDoubleJump = true;
					jumpsound.Play ();

				} else {
					if (canDoubleJump) {
						canDoubleJump = false;
						rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
						rb2d.AddForce (Vector2.up * jumpPower * .8f);
						jumpsound.Play ();

					}
				}

			}
			/*	if (Input.GetButtonUp ("Jump")){
			speed = 50;
		}*/

			if (currentHealth > maxHealth) {
				currentHealth = maxHealth;
			}

			if (currentHealth <= 0) {
				StartCoroutine ("Die");
			}

		}

	}
		

	void FixedUpdate() {

		//moving player left or right
		float h = Input.GetAxisRaw("Horizontal"); // x axis, h is left/right -1/+1
		rb2d.AddForce((Vector2.right * speed) * h);

		// limiting speed of player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
		

	public void Damage(int dmg) {
		if (invincible == false) {
			currentHealth -= dmg;
			invincible = true;
			if (currentHealth < 0) {
				currentHealth = 0;
			}
			gameObject.GetComponent<Animation> ().Play ("vitez_bez_dmg");
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			Invoke("resetInvincible", 1);
		}
	}

	public IEnumerator knockBack (float knockBackDur, float knockBackPow, Vector3 knockBackDir, int xBack) {

		float timer = 0;

		while (knockBackDur > timer) {
			timer += Time.deltaTime;
			rb2d.velocity = new Vector2 (0, 0);
			if (transform.localScale.x  == -1) {
				rb2d.AddForce (new Vector3 (knockBackDir.x * xBack, Mathf.Abs(knockBackDir.y * knockBackPow), transform.position.z));
				//player.GetComponent<Vitez>().enabled = false;
				yield return new WaitForSeconds (0.3f);
				//player.GetComponent<Vitez>().enabled = true;

			}

			if (transform.localScale.x  == 1) {
				rb2d.AddForce (new Vector3 (knockBackDir.x * -xBack, Mathf.Abs(knockBackDir.y * knockBackPow), transform.position.z));
				//player.GetComponent<Vitez>().enabled = false;
				yield return new WaitForSeconds (0.3f);
				//player.GetComponent<Vitez>().enabled = true;
			}
				
			}
			
	}

		void resetInvincible() {
			invincible = false;
		}

	IEnumerator Die() {
		rb2d.velocity = Vector2.zero;
		yield return new WaitForSeconds (0.2f);
		deathMenu.gameObject.SetActive (true);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("coin")) {
			Destroy (col.gameObject);
			coinmaster.points += 10;
			coinaudio.GetComponent<AudioSource> ().Play ();
		}
	}

}
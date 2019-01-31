using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;
	private bool attackingG = false;
	private bool attackingB = false;
	private Vitez vitez;

	private float attackTimer = 0;
	private float attackCooldown = 0.3f;

	public PolygonCollider2D attackTriggerR;
	public PolygonCollider2D attackTriggerG;
	public PolygonCollider2D attackTriggerB;
	public AudioSource attackSound;

	private Animator anim;

	void Start() {
		vitez = gameObject.GetComponentInParent<Vitez>();
	}

	void Awake() {
		anim = gameObject.GetComponent<Animator>();
		attackTriggerR.enabled = false;
		attackTriggerG.enabled = false;
		attackTriggerB.enabled = false;
	}

	void Update() {
		if (vitez.counter > 0) {
			if (Input.GetKeyDown("y") && !attacking && !attackingB && !attackingG){ /// RED
				
			attacking = true;
			attackTimer = attackCooldown;
				Invoke ("delayHitboxR", 0.17f);
				attackSound.Play ();
				vitez.rb2d.velocity = Vector2.zero;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
			else {
				attacking = false;
				attackTriggerR.enabled = false;
			}
		}

			if (Input.GetKeyDown("x") && !attacking && !attackingB && !attackingG){ /// RED

				attackingG = true;
				attackTimer = attackCooldown;
				Invoke ("delayHitboxG", 0.17f);
				attackSound.Play ();
				vitez.rb2d.velocity = Vector2.zero;
			}

			if (attackingG) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				}
				else {
					attackingG = false;
					attackTriggerG.enabled = false;
				}
			}

			if (Input.GetKeyDown("c") && !attacking && !attackingB && !attackingG){ /// RED

				attackingB = true;
				attackTimer = attackCooldown;
				Invoke ("delayHitboxB", 0.17f);
				attackSound.Play ();
				vitez.rb2d.velocity = Vector2.zero;
			}

			if (attackingB) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				}
				else {
					attackingB = false;
					attackTriggerB.enabled = false;
				}
			}
		}
		anim.SetBool ("Attacking", attacking);
		anim.SetBool ("AttackingG", attackingG);
		anim.SetBool ("AttackingB", attackingB);
	}

	void delayHitboxR() {
		attackTriggerR.enabled = true;

	}

	void delayHitboxG() {
		attackTriggerG.enabled = true;

	}

	void delayHitboxB() {
		attackTriggerB.enabled = true;

	}
		
}

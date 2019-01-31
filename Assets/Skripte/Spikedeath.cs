using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikedeath : MonoBehaviour {

	private Vitez player; // pristup zdravlju
	public float yKnockBack = 80; // jačina odbacivanja po y osi
	public int xKnockBack = 7; // jačina odbacivanja po x osi
	public int dmg = 2; // šteta pri dodiru

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Vitez> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player") && !col.isTrigger) {
			if (player.invincible == false) {
				player.Damage (dmg);
				StartCoroutine (player.knockBack (0.001f, yKnockBack, player.transform.position, xKnockBack));
			}
		}
	}
}


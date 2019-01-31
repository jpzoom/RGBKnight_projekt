using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fbScript : MonoBehaviour {

	public int fbdamage = 1;
	public bool invincible = false;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag("Player") && col.isTrigger != true) {
			if(invincible == false)
			{
				invincible = true;
				col.GetComponent<Vitez>().Damage(fbdamage);
				Invoke ("resetInvincible", 1);
			}
			StartCoroutine ("deathFB");

		}


	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	IEnumerator deathFB() {
		yield return new WaitForSeconds (0.02f);
		Destroy(gameObject);
	}

	void resetInvincible() {
		Debug.Log ("Invincible = " +invincible);
		invincible = false;
	}
}
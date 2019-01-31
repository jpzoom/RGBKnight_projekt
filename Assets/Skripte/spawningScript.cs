using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningScript : MonoBehaviour {

	public float x = 0;
	public float y = 0;
	public GameObject enemy;
	Vector2 whereToSpawn;
	public bool hasSpawned = false;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player") && !col.isTrigger) {
			if (hasSpawned == false) {
				hasSpawned = true;
				whereToSpawn = new Vector2 (x, y);
				Instantiate (enemy, whereToSpawn, Quaternion.identity);
			}
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] healthSprites;

	public Image HealthUI;
	private Vitez vitez;

	void Start() {
		vitez = GameObject.FindGameObjectWithTag ("Player").GetComponent<Vitez> ();

	}

	void Update () {
		HealthUI.sprite = healthSprites[vitez.currentHealth];
	}
}


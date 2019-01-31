using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinMaster : MonoBehaviour {

	public int points;
	public Text pointsText;

	void Update() {
		pointsText.text = ("Points:\n" + points);
	}
}

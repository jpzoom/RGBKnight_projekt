using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject vitez;

	public bool bounds;
	public float offsetCameraY = 2;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	void Update () {


			vitez = GameObject.FindGameObjectWithTag ("Player");
		
		
	}

	void FixedUpdate() {

		/*if (!vitez) {
			posX = Mathf.SmoothDamp (transform.position.x, placeholder.transform.position.x, ref velocity.x, smoothTimeX);
			posY = Mathf.SmoothDamp (transform.position.y, placeholder.transform.position.y + offsetCameraY, ref velocity.y, smoothTimeY);
		

			transform.position = new Vector3 (posX, posY, transform.position.z);

		} else if (vitez && placeholder) {

			posX = Mathf.SmoothDamp (transform.position.x, placeholder.transform.position.x, ref velocity.x, smoothTimeX);
			posY = Mathf.SmoothDamp (transform.position.y, placeholder.transform.position.y + offsetCameraY, ref velocity.y, smoothTimeY);


			transform.position = new Vector3 (posX, posY, transform.position.z);
		}*/

		float posX = Mathf.SmoothDamp (transform.position.x, vitez.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, vitez.transform.position.y + offsetCameraY, ref velocity.y, smoothTimeY);


		transform.position = new Vector3 (posX, posY, transform.position.z);


		if (bounds) {
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
											  Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
											  Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}



		vitez = GameObject.FindGameObjectWithTag ("Player");
	}

}

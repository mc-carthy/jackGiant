using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distBetweenClouds = 3f;
	private float minX, maxX;
	private float lastCloudPosY;
	private float controlX;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;

	private void Awake () {
		//player = FindObjectOfType<PlayerController> ();
		controlX = 0;
		SetMinMaxX ();
		CreateClouds ();
	}

	private void SetMinMaxX () {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = bounds.x - 0.5f;
		minX = -maxX;
	}

	private void Shuffle (GameObject[] objects) {
		for (int i = 0; i < objects.Length; i++) {
			GameObject temp = objects [i];
			int random = Random.Range (i, objects.Length);
			objects [i] = objects [random];
			objects [random] = temp;
		}
	}

	private void CreateClouds () {
		Shuffle (clouds);
		float posY = 0f;

		for (int i = 0; i < clouds.Length; i++) {
			Vector3 temp = clouds [i].transform.position;
			temp.y = posY;
			temp.x = Random.Range (minX, maxX);
			if (controlX == 0) {
				temp.x = Random.Range (0.0f, maxX);
				controlX = 1;
			} else if (controlX == 1) {
				temp.x = Random.Range (0.0f, minX);
				controlX = 2;
			} else if (controlX == 2) {
				temp.x = Random.Range (1.0f, maxX);
				controlX = 3;
			} else if (controlX == 3) {
				temp.x = Random.Range (-1.0f, minX);
				controlX = 0;
			}
			lastCloudPosY = posY;
			clouds [i].transform.position = temp;
			posY -= distBetweenClouds;
		}
	}
}

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
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	private void Start () {
		PositionPlayer ();
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

	private void PositionPlayer () {
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		for (int i = 0; i < darkClouds.Length; i++) {
			if (darkClouds [i].transform.position.y == 0f) {
				Vector3 temp0 = darkClouds [i].transform.position;

				darkClouds [i].transform.position = new Vector3 (cloudsInGame [0].transform.position.x,
																 cloudsInGame [0].transform.position.y,
																 cloudsInGame [0].transform.position.z);

				cloudsInGame [0].transform.position = temp0;
			}
		}

		Vector3 temp1 = cloudsInGame [0].transform.position;

		for (int i = 1; i < cloudsInGame.Length; i++) {
			if (temp1.y < cloudsInGame [i].transform.position.y) {
				temp1 = cloudsInGame [i].transform.position;
			}
		}

		temp1.y += 1f;

		player.transform.position = temp1;
	}

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Cloud" || col.tag == "Deadly") {
			if (col.transform.position.y == lastCloudPosY) {
				Shuffle (clouds);
				Shuffle (collectables);

				Vector3 temp = col.transform.position;

				for (int i = 0; i < clouds.Length; i++) {
					if (clouds [i].activeInHierarchy) {
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

						temp.y -= distBetweenClouds;

						lastCloudPosY = temp.y;

						clouds [i].transform.position = temp;
						clouds [i].SetActive (true);
					}
				}
			}
		}
	}
}

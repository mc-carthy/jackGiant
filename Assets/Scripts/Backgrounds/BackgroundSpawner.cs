using UnityEngine;
using System.Collections;

public class BackgroundSpawner : MonoBehaviour {

	private GameObject[] backgrounds;
	private float lastY;

	private void Start () {
		GetBackgroundsSetLastY ();
	}

	private void GetBackgroundsSetLastY () {
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");
		lastY = backgrounds [0].transform.position.y;

		for (int i = 1; i < backgrounds.Length; i++) {
			if (lastY > backgrounds [i].transform.position.y) {
				lastY = backgrounds [i].transform.position.y;
			}
		}
	}

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Background") {
			if (col.transform.position.y == lastY) {
				Vector3 temp = col.transform.position;
				float height = ((BoxCollider2D)col).size.y;

				for (int i = 0; i < backgrounds.Length; i++) {
					if (!backgrounds [i].activeInHierarchy) {
						temp.y -= height;
						lastY = temp.y;

						backgrounds [i].transform.position = temp;
						backgrounds [i].SetActive (true);
					}
				}
			}
		}
	}
}

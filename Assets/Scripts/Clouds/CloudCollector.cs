using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Cloud" || col.tag == "Deadly") {
			col.gameObject.SetActive (false);
		}
	}
}

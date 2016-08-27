using UnityEngine;
using System.Collections;

public class BackgroundCollector : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Background") {
			col.gameObject.SetActive (false);
		}
	}
}

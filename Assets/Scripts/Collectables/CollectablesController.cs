using UnityEngine;
using System.Collections;

public class CollectablesController : MonoBehaviour {

	private void OnEnable () {
		Invoke ("Destroy", 6f);
	}

	private void Destroy () {
		gameObject.SetActive (false);
	}
}

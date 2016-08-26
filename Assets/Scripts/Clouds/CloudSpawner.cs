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
		player = FindObjectOfType<PlayerController> ();
	}
}

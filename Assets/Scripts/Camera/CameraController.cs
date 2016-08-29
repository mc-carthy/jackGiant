using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[HideInInspector]
	public bool moveCamera;

	private float speed = 1f;
	private float acc = 0.2f;
	private float maxSpeed = 3.5f;

	private float easySpeed = 3.5f;
	private float mediumSpeed = 4f;
	private float hardSpeed = 4.5f;

	private void Start () {
		moveCamera = true;

		if (GamePreferences.GetEasyDifficulty () == 1) {
			maxSpeed = easySpeed;
		}
		if (GamePreferences.GetMediumDifficulty () == 1) {
			maxSpeed = mediumSpeed;
		}
		if (GamePreferences.GetHardDifficulty () == 1) {
			maxSpeed = hardSpeed;
		}
	}

	private void Update () {
		if (moveCamera) {
			MoveCamera ();
		}
	}

	private void MoveCamera () {
		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y, oldY, newY);

		transform.position = temp;

		speed += acc * Time.deltaTime;

		if (speed > maxSpeed) {
			speed = maxSpeed;
		}
	}
}

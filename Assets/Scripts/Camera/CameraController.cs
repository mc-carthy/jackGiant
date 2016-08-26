using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[HideInInspector]
	public bool moveCamera;

	private float speed = 1f;
	private float acc = 0.2f;
	private float maxSpeed = 3.2f;

	private void Start () {
		moveCamera = true;
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

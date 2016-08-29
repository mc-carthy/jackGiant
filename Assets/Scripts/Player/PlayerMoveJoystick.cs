using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;


	private Rigidbody2D rb;
	private Animator anim;

	private bool moveLeft, moveRight;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void FixedUpdate () {
		if (moveLeft) {
			MoveLeft ();
		}
		if (moveRight) {
			MoveRight ();
		}
	}

	public void SetMoveLeft (bool moveLeft) {
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}

	public void StopMoving () {
		moveLeft = moveRight = false;
		anim.SetBool ("Walk", false);
	}

	private void MoveLeft () {
		float forceX = 0f;
		float vel = Mathf.Abs (rb.velocity.x);
		if (vel < maxVelocity) {
			forceX = -speed;
		}
		anim.SetBool ("Walk", true);
		Vector3 temp = transform.localScale;
		temp.x = -1.3f;
		transform.localScale = temp;

		rb.AddForce(new Vector2 (forceX, 0));
	}

	private void MoveRight () {
		float forceX = 0f;
		float vel = Mathf.Abs (rb.velocity.x);
		if (vel < maxVelocity) {
			forceX = speed;
		}
		anim.SetBool ("Walk", true);
		Vector3 temp = transform.localScale;
		temp.x = 1.3f;
		transform.localScale = temp;

		rb.AddForce(new Vector2 (forceX, 0));
	}
}

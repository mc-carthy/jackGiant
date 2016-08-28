using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;


	private Rigidbody2D rb;
	private Animator anim;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	private void FixedUpdate () {
		PlayerMoveKeyboard ();
	}

	private void PlayerMoveKeyboard () {
		float forceX = 0f;
		float vel = Mathf.Abs (rb.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity) {
				forceX = speed;
				anim.SetBool ("Walk", true);
				Vector3 temp = transform.localScale;
				temp.x = 1.3f;
				transform.localScale = temp;			}
		} else if (h < 0) {
			if (vel < maxVelocity) {
				forceX = -speed;
				anim.SetBool ("Walk", true);
				Vector3 temp = transform.localScale;
				temp.x = -1.3f;
				transform.localScale = temp;
			}
		} else {
			anim.SetBool ("Walk", false);
		}
		rb.AddForce(new Vector2 (forceX, 0));
	}
}

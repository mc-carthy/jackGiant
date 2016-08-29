using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private PlayerMoveJoystick playerMove;

	private void Awake () {
		playerMove = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMoveJoystick> ();
	}

	public void OnPointerDown (PointerEventData data) {
		if (gameObject.name == "left") {
			playerMove.SetMoveLeft (true);
		}
		if (gameObject.name == "right") {
			playerMove.SetMoveLeft (false);
		}
	}

	public void OnPointerUp (PointerEventData data) {
		playerMove.StopMoving ();
	}
}

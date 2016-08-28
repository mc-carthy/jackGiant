using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	[SerializeField]
	private AudioClip coinClip = null, lifeClip = null;
	private CameraController cameraScript;
	private Vector3 previousPos;
	private bool countScore;

	private void Awake () {
		cameraScript = Camera.main.GetComponent<CameraController> ();
	}

	private void Start () {
		previousPos = transform.position;
		countScore = true;
	}

	private void Update () {
		CountScore ();
	}

	private void CountScore () {
		if (countScore) {
			if (transform.position.y < previousPos.y) {
				scoreCount++;
				GameController.instance.SetScore (scoreCount);
			}
			previousPos = transform.position;
		}
	}

	private void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Coin") {
			coinCount++;
			scoreCount += 200;
			GameController.instance.SetScore (scoreCount);
			GameController.instance.SetCoinScore (coinCount);
			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			col.gameObject.SetActive (false);
		}
		if (col.tag == "Life") {
			lifeCount++;
			scoreCount += 300;
			GameController.instance.SetScore (scoreCount);
			GameController.instance.SetLifeScore (lifeCount);
			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			col.gameObject.SetActive (false);
		}
		if (col.tag == "Bounds") {
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3 (500, 500, 0);
			lifeCount--;
			GameController.instance.SetLifeScore (lifeCount);
		}
		if (col.tag == "Deadly") {
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3 (500, 500, 0);
			lifeCount--;
			GameController.instance.SetLifeScore (lifeCount);
		}

	}

}

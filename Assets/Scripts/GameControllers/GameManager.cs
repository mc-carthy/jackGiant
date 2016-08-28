using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDeath;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	private void Awake () {
		MakeSingleton ();
	}

	private void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	private void OnLevelWasLoaded () {
		if (SceneManager.GetActiveScene ().name == "main") {
			if (gameRestartedAfterPlayerDeath) {
				GameController.instance.SetScore (score);
				GameController.instance.SetCoinScore (coinScore);
				GameController.instance.SetLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;

			} else if (gameStartedFromMainMenu) {
				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;

				GameController.instance.SetScore (score);
				GameController.instance.SetCoinScore (coinScore);
				GameController.instance.SetLifeScore (lifeScore);
			}
		}
	}

	public void CheckGameStatus (int score, int coinScore, int lifeScore) {
		if (lifeScore < 0) {
			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDeath = false;
			GameController.instance.GameOverShowPanel (score, coinScore);
		} else {
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			gameRestartedAfterPlayerDeath = true;
			gameStartedFromMainMenu = false;

			GameController.instance.PlayerDiedRestartGame ();
		}
	}
}

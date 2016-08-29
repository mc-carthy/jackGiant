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

			if (GamePreferences.GetEasyDifficulty () == 1) {
				int highScore = GamePreferences.GetEasyDifficultyHighScore ();
				int highScoreCoin = GamePreferences.GetEasyDifficultyCoinScore ();

				if (score > highScore) {
					GamePreferences.SetEasyDifficultyHighScore (score);
				}
				if (coinScore > highScoreCoin) {
					GamePreferences.SetEasyDifficultyCoinScore (coinScore);
				}

			}

			if (GamePreferences.GetMediumDifficulty () == 1) {
				int highScore = GamePreferences.GetMediumDifficultyHighScore ();
				int highScoreCoin = GamePreferences.GetMediumDifficultyCoinScore ();

				if (score > highScore) {
					GamePreferences.SetMediumDifficultyHighScore (score);
				}
				if (coinScore > highScoreCoin) {
					GamePreferences.SetMediumDifficultyCoinScore (coinScore);
				}

			}

			if (GamePreferences.GetHardDifficulty () == 1) {
				int highScore = GamePreferences.GetHardDifficultyHighScore ();
				int highScoreCoin = GamePreferences.GetHardDifficultyCoinScore ();

				if (score > highScore) {
					GamePreferences.SetHardDifficultyHighScore (score);
				}
				if (coinScore > highScoreCoin) {
					GamePreferences.SetHardDifficultyCoinScore (coinScore);
				}

			}
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

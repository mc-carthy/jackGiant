using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText, coinText;

	private void Start () {
		SetScoreBasedOnDifficulty ();
	}

	public void GoToMainMenu () {
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	private void SetScoreBasedOnDifficulty () {
		if (GamePreferences.GetEasyDifficulty () == 1) {
			SetScore (GamePreferences.GetEasyDifficultyHighScore (), GamePreferences.GetEasyDifficultyCoinScore());
		}
		if (GamePreferences.GetMediumDifficulty () == 1) {
			SetScore (GamePreferences.GetMediumDifficultyHighScore (), GamePreferences.GetMediumDifficultyCoinScore());
		}
		if (GamePreferences.GetHardDifficulty () == 1) {
			SetScore (GamePreferences.GetHardDifficultyHighScore (), GamePreferences.GetHardDifficultyCoinScore());
		}
	}

	private void SetScore (int score, int coinScore) {
		scoreText.text = score.ToString ();
		coinText.text = "x " + coinScore.ToString ();
	}
}

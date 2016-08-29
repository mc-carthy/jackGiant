using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel, readyButton;

	private void Awake () {
		CreateInstance ();
	}

	private void Start () {
		Time.timeScale = 0f;
	}

	private void CreateInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void GameOverShowPanel (int finalScore, int finalCoinScore) {
		gameOverPanel.SetActive (true);
		gameOverScoreText.text = finalScore.ToString ();
		gameOverCoinText.text = "x " + finalCoinScore.ToString ();
		StartCoroutine (GameOverLoadMainMenu ());
	}

	public void PlayerDiedRestartGame () {
		StartCoroutine (PlayerDiedRestartLevel ());
	}

	public void SetScore (int score) {
		scoreText.text = score.ToString();
	}

	public void SetCoinScore (int score) {
		coinText.text = "x" + score.ToString();
	}

	public void SetLifeScore (int score) {
		if (score < 0) {
			score = 0;
		}
		lifeText.text = "x" + score.ToString();
	}

	public void Ready () {
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

	public void PauseGame () {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void ResumeGame () {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame () {
		Time.timeScale = 1f;
		//SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		SceneFader.instance.LoadLevel ("menu");
	}

	private IEnumerator GameOverLoadMainMenu () {
		yield return new WaitForSeconds (3f);
		//SceneManager.LoadScene ("menu", LoadSceneMode.Single);
		SceneFader.instance.LoadLevel ("menu");
	}

	private IEnumerator PlayerDiedRestartLevel () {
		yield return new WaitForSeconds (1f);
		//SceneManager.LoadScene ("main", LoadSceneMode.Single);
		SceneFader.instance.LoadLevel ("main");

	}
}

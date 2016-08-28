using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText;

	[SerializeField]
	private GameObject pausePanel;

	private void Awake () {
		CreateInstance ();
	}

	private void CreateInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void SetScore (int score) {
		scoreText.text = score.ToString();
	}

	public void SetCoinScore (int score) {
		coinText.text = "x" + score.ToString();
	}

	public void SetLifeScore (int score) {
		lifeText.text = "x" + score.ToString();
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
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}
}

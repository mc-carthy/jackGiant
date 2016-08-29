using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	[SerializeField]
	private Button musicBtn;

	[SerializeField]
	private Sprite[] musicIcons;

	private void Start () {
		CheckToPlayMusic ();
	}

	public void StartGame () {
		GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene ("main", LoadSceneMode.Single);
	}

	public void GoToHighscore () {
		SceneManager.LoadScene ("highscore", LoadSceneMode.Single);
	}

	public void GoToOptions () {
		SceneManager.LoadScene ("options", LoadSceneMode.Single);
	}

	public void ToggleSound () {
		if (GamePreferences.GetMusicState() == 0) {
			GamePreferences.SetMusicState (1);
		} else {
			GamePreferences.SetMusicState (0);
		}
		CheckToPlayMusic ();
	}

	public void Quit () {
		Application.Quit ();
	}

	private void CheckToPlayMusic () {
		if (GamePreferences.GetMusicState () == 1) {
			MusicManager.instance.PlayMusic (true);
			musicBtn.image.sprite = musicIcons [1];
		} else {
			MusicManager.instance.PlayMusic (false);
			musicBtn.image.sprite = musicIcons [0];
		}
	}
}

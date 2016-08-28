using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

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

	}

	public void Quit () {
		Application.Quit ();
	}
}

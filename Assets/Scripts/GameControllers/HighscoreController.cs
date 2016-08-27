using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighscoreController : MonoBehaviour {

	public void GoToMainMenu () {
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public void GoToMainMenu () {
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}
}

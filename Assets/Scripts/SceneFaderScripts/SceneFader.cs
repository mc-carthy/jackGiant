using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadePanel;

	[SerializeField]
	private Animator anim;

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

	public void LoadLevel(string level) {
		StartCoroutine (FadeInOut (level));
	}

	private IEnumerator FadeInOut (string level) {
		fadePanel.SetActive (true);
		anim.Play ("FadeIn");
		yield return StartCoroutine (Coroutine.WaitForRealSeconds (1f));

		SceneManager.LoadScene (level, LoadSceneMode.Single);
		anim.Play ("FadeOut");
		yield return StartCoroutine (Coroutine.WaitForRealSeconds (0.7f));

		fadePanel.SetActive (false);
	}
}

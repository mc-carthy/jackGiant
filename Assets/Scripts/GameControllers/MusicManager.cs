using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public static MusicManager instance;

	private AudioSource source;

	private void Awake () {
		MakeSingleton ();
		source = GetComponent<AudioSource> ();
	}

	private void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void PlayMusic (bool play) {
		if (play) {
			if (!source.isPlaying) {
				source.Play ();
			}
		} else {
			if (source.isPlaying) {
				source.Stop ();
			}
		}
	}
}

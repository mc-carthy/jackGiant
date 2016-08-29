﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsController : MonoBehaviour {

	[SerializeField]
	private GameObject easySign, mediumSign, hardSign;

	private void Start () {
		SetDifficulty ();
	}

	public void GoToMainMenu () {
		SceneManager.LoadScene ("menu", LoadSceneMode.Single);
	}

	public void EasyDifficulty () {
		GamePreferences.SetEasyDifficulty (1);
		GamePreferences.SetMediumDifficulty (0);
		GamePreferences.SetHardDifficulty (0);

		easySign.SetActive (true);
		mediumSign.SetActive (false);
		hardSign.SetActive (false);
	}

	public void MediumDifficulty () {
		GamePreferences.SetEasyDifficulty (0);
		GamePreferences.SetMediumDifficulty (1);
		GamePreferences.SetHardDifficulty (0);

		easySign.SetActive (false);
		mediumSign.SetActive (true);
		hardSign.SetActive (false);
	}

	public void HardDifficulty () {
		GamePreferences.SetEasyDifficulty (0);
		GamePreferences.SetMediumDifficulty (0);
		GamePreferences.SetHardDifficulty (1);

		easySign.SetActive (false);
		mediumSign.SetActive (false);
		hardSign.SetActive (true);
	}

	private void SetInitialDifficulty (string difficulty) {
		switch (difficulty) {
		case("easy"):
			easySign.SetActive (true);
			mediumSign.SetActive (false);
			hardSign.SetActive (false);
			break;
		case("medium"):
			easySign.SetActive (false);
			mediumSign.SetActive (true);
			hardSign.SetActive (false);
			break;
		case("hard"):
			easySign.SetActive (false);
			mediumSign.SetActive (false);
			hardSign.SetActive (true);	
			break;
		}
	}

	private void SetDifficulty () {
		if (GamePreferences.GetEasyDifficulty () == 1) {
			SetInitialDifficulty ("easy");
		}
		if (GamePreferences.GetMediumDifficulty () == 1) {
			SetInitialDifficulty ("medium");
		}
		if (GamePreferences.GetHardDifficulty () == 1) {
			SetInitialDifficulty ("hard");
		}
	}
}

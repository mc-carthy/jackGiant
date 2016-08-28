using UnityEngine;
using System.Collections;

public static class GamePreferences {

	public static string easyDifficulty = "easyDifficulty";
	public static string mediumDifficulty = "mediumDifficulty";
	public static string hardDifficulty = "hardDifficulty";

	public static string easyDifficultyHighScore = "easyDifficultyHighScore";
	public static string mediumDifficultyHighScore = "mediumDifficultyHighScore";
	public static string hardDifficultyHighScore = "hardDifficultyHighScore";

	public static string easyDifficultyCoinScore = "easyDifficultyCoinScore";
	public static string mediumDifficultyCoinScore = "mediumDifficultyCoinScore";
	public static string hardDifficultyCoinScore = "hardDifficultyCoinScore";

	public static string isMusicOn = "isMusicOn";

	// Note: Intergers are used to represent boolean values. 0 - false, 1 - true

	public static void SetMusicState (int state) {
		PlayerPrefs.SetInt (GamePreferences.isMusicOn, state);
	}

	public static int GetMusicState () {
		return PlayerPrefs.GetInt (GamePreferences.isMusicOn);
	}

	public static void SetEasyDifficulty (int state) {
		PlayerPrefs.SetInt (GamePreferences.easyDifficulty, state);
	}

	public static int GetEasyDifficulty () {

		return PlayerPrefs.GetInt (GamePreferences.easyDifficulty);
	}

	public static void SetMediumDifficulty (int state) {
		PlayerPrefs.SetInt (GamePreferences.mediumDifficulty, state);
	}

	public static int GetMediumDifficulty () {
		return PlayerPrefs.GetInt (GamePreferences.mediumDifficulty);
	}

	public static void SetHardDifficulty (int state) {
		PlayerPrefs.SetInt (GamePreferences.hardDifficulty, state);
	}

	public static int GetHardDifficulty () {
		return PlayerPrefs.GetInt (GamePreferences.hardDifficulty);
	}

	public static void SetEasyDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.easyDifficultyHighScore, score);
	}

	public static int GetEasyDifficultyHighScore () {

		return PlayerPrefs.GetInt (GamePreferences.easyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.mediumDifficultyHighScore, score);
	}

	public static int GetMediumDifficultyHighScore () {
		return PlayerPrefs.GetInt (GamePreferences.mediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.hardDifficultyHighScore, score);
	}

	public static int GetHardDifficultyHighScore () {
		return PlayerPrefs.GetInt (GamePreferences.hardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.easyDifficultyCoinScore, score);
	}

	public static int GetEasyDifficultyCoinScore () {

		return PlayerPrefs.GetInt (GamePreferences.easyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.mediumDifficultyCoinScore, score);
	}

	public static int GetMediumDifficultyCoinScore () {
		return PlayerPrefs.GetInt (GamePreferences.mediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.hardDifficultyCoinScore, score);
	}

	public static int GetHardDifficultyCoinScore () {
		return PlayerPrefs.GetInt (GamePreferences.hardDifficultyCoinScore);
	}
}
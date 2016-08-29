using UnityEngine;
using System.Collections;

public static class Coroutine {

	public static IEnumerator WaitForRealSeconds (float time) {
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + time) {
			yield return null;
		}
	}
}

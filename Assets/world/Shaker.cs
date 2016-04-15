using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

	public float duration;
	public float magnitude;

	public void shake() {
		StartCoroutine ("Shake");
	}

	IEnumerator Shake() {

		float elapsed = 0.0f;

		Vector3 originalCamPos = gameObject.transform.position;

		while (elapsed < duration) {

			elapsed += Time.deltaTime;          

			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;

			gameObject.transform.position = originalCamPos + new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		gameObject.transform.position = originalCamPos;
	}
}

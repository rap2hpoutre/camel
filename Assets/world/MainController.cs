using UnityEngine;

using System.Collections;

public class MainController : MonoBehaviour {

    public GameObject background;

	public static bool isQuitting = false;
	public static bool paused = false;
    

    public void blinkScreen()
    {
        StartCoroutine(blinkScreenWait(0.05f));
    }

    IEnumerator blinkScreenWait(float seconds)
    {
        background.transform.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(seconds);
        background.transform.GetComponent<Renderer>().enabled = true;
    }

    public void pauseGame()
    {
		paused = true;
    }

    public void resumeGame()
    {
		paused = false;
    }

	void OnApplicationQuit()
	{
		isQuitting = true;
	}

	void OnLevelWasLoaded(int level)
	{
		isQuitting = false;
	}
}

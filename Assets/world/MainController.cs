using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class MainController : MonoBehaviour {

    public GameObject background;
	public Shaker shaker;

	private static Text UIScore;
	private static Text UITime;
	private static int score = 0;
	public float time = 30;

	public static bool isQuitting = false;
	public static bool paused = false;

	void Awake() 
	{
		UIScore = GameObject.Find ("UICanvas").gameObject.transform.Find ("ScoreText").gameObject.GetComponent<Text> ();
		UITime = GameObject.Find ("UICanvas").gameObject.transform.Find ("TimeText").gameObject.GetComponent<Text> ();
		shaker = GameObject.Find("CameraContainer").GetComponent<Shaker>();
		InvokeRepeating ("BlinkText", 0, 0.1f);
	}

	void BlinkText ()
	{
		UIScore.color = new Color ( Mathf.Min(Random.value + 0.5f, 1), Mathf.Min(Random.value + 0.5f, 1), Mathf.Min(Random.value + 0.5f, 1));
		UITime.color = new Color ( Mathf.Min(Random.value + 0.5f, 1), Mathf.Min(Random.value + 0.5f, 1), Mathf.Min(Random.value + 0.5f, 1));
	}

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
		Debug.Log ("Level " + level + " started");
		IncrementScore (0);
		isQuitting = false;
	}

	static public void IncrementScore(int value)
	{
		score += value;
		UIScore.text = "Score: " + score ;
	}

	void FixedUpdate() {
		
		time -= Time.fixedDeltaTime;
		var seconds = time;
		var fraction = (time * 10) % 9;

		UITime.text = string.Format ("Time: {0:00}.{1:0}", seconds, fraction);
	}
}

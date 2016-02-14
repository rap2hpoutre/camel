using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections;

public class Main : MonoBehaviour {

    public StupidGruntController stupidGrunt;
    public GameObject player;
    public GameObject background;
    public GameObject counter;

    // Use this for initialization
    void Awake () {
        for (int i=0; i<25; i++)
        {
            Vector2 position;
            if (i % 4 == 0)
            {
                position = new Vector2(Random.Range(2, 5), Random.Range(-5, 5));
            }
            else if (i % 4 == 1)
            {
                position = new Vector2(Random.Range(-2, -5), Random.Range(-5, 5));
            }
            else if (i % 4 == 2)
            {
                position = new Vector2(Random.Range(-5, 5), Random.Range(-2, -5));
            }
            else 
            {
                position = new Vector2(Random.Range(-5, 5), Random.Range(2, 5));
            }
            
            StupidGruntController clone = (StupidGruntController)Instantiate(stupidGrunt, transform.position, Quaternion.identity);
            clone.player = player;
            clone.transform.position = position;
        }

        StartCoroutine(startWait());   
    }

    IEnumerator startWait()
    {
        pauseGame();
        for (int i = 3; i >= 0; i--)
        {
            counter.GetComponent<RectTransform>().localScale = new Vector3(.5f,.5f,1);
            if (i == 0)
            {
                counter.GetComponent<Text>().text = "GO!";
                resumeGame();
            }
            else
            {
                counter.GetComponent<Text>().text = i.ToString();
            }
            for (float j=0; j<100; j++)
            {
                counter.GetComponent<RectTransform>().localScale = new Vector3(.5f+j /120, .5f+j /120, 1);
                yield return new WaitForSeconds(.01f);
            }
        }
        Destroy(counter);
    }
	
	// Update is called once per frame
	void Update () {
	
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

    void pauseGame()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }

    void resumeGame()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
    }
}

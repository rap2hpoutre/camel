using UnityEngine;

using System.Collections;

public class MainController : MonoBehaviour {

    public GameObject background;
    

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
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void resumeGame()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
    }
}

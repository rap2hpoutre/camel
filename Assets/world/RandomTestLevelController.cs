using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomTestLevelController : MonoBehaviour {

    public GameObject counter;
    public GameObject player;
    public StupidGruntController stupidGrunt;
    private MainController mainController;

    void Awake()
    {
        mainController = GameObject.Find("Main").GetComponent<MainController>();
        for (int i = 0; i < 25; i++)
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
        mainController.pauseGame();
        for (int i = 3; i >= 0; i--)
        {
            counter.GetComponent<RectTransform>().localScale = new Vector3(.5f, .5f, 1);
            if (i == 0)
            {
                counter.GetComponent<Text>().text = "GO!";
                mainController.resumeGame();
            }
            else
            {
                counter.GetComponent<Text>().text = i.ToString();
            }
            for (float j = 0; j < 100; j++)
            {
                counter.GetComponent<RectTransform>().localScale = new Vector3(.5f + j / 120, .5f + j / 120, 1);
                yield return new WaitForSeconds(.01f);
            }
        }
        Destroy(counter);
    }
}

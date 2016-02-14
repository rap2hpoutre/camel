using UnityEngine;
using System.Collections;

public class StupidGruntController : MonoBehaviour {

    public GameObject player;
    private Rigidbody2D rb2d;
    private float speed = 0.02f;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (paused) return;

        Vector2 direction = new Vector2();

	    if (player.transform.position.x < rb2d.transform.position.x)
        {
            direction.x = -1;
        }
        else if (player.transform.position.x > rb2d.transform.position.x)
        {
            direction.x = 1;
        }

        if (player.transform.position.y < rb2d.transform.position.y)
        {
            direction.y = -1;
        }
        else if (player.transform.position.y > rb2d.transform.position.y)
        {
            direction.y = 1;
        }

        rb2d.transform.Translate(direction * speed);
    }

    protected bool paused;


    void OnPauseGame()
    {
        paused = true;
    }


    void OnResumeGame()
    {
        paused = false;
    }
}

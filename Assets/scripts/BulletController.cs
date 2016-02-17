using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public Vector2 direction;
    public float speed = 10;
    private MainController mainController;

    void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        mainController = GameObject.Find("Main").GetComponent<MainController>();
    }
	
    void FixedUpdate() {
        rb2d.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "camel")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "grunt")
        {
			mainController.blinkScreen();
            Destroy(col.gameObject);
        }
    }


}

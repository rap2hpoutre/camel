using UnityEngine;
using System.Collections;

public class CamelController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;  

    public BulletController bullet;

    private float cooldown = 0.35f;
    private float timeStamp = 0;

    private Vector2 direction;
    
    protected bool paused;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D> ();
        direction = new Vector2(1, 0);

    }

	void FixedUpdate()
	{
        if (paused) return;

        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

        if ((moveHorizontal != 0) || (moveVertical != 0))
        {
            Vector2 tmpDirection = new Vector2(moveHorizontal, moveVertical);
            rb2d.transform.Translate(tmpDirection * speed);
            if (!Input.GetKey("space"))
            {
                direction = tmpDirection;
            }
            
        }

        if (timeStamp <= Time.time)
        {
            BulletController clone = (BulletController)Instantiate(bullet, transform.position, Quaternion.identity);
            clone.direction = direction;
            timeStamp = Time.time + cooldown;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "grunt")
        {
            Debug.Log("Mort");
        }
    }

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }
}

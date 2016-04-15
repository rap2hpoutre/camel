using UnityEngine;
using System.Collections;

public class BouncingGruntController : GruntController {

	private float directionX;
	private float directionY;

	// Use this for initialization
	void Awake () {
		directionX = Random.value * 2 - 1;
		directionY = Random.value * 2 - 1;
		speed = 0.1f;
	}

	void FixedUpdate() 
	{
		transform.Translate (directionX * speed, directionY * speed, 0, Space.World);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag != "grunt")
		{
			if (Mathf.Round(col.contacts [0].normal.x) != 0) {
				directionX *= -1;
			} else if (Mathf.Round(col.contacts [0].normal.y) != 0) {
				directionY *= -1;
			}
		}
	}
}

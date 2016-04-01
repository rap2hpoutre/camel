using UnityEngine;
using System.Collections;

public class OneAxisGruntController : GruntController {

	public int direction = 1;
	public bool vertical = true;

	void FixedUpdate() 
	{
		if (vertical) {
			transform.Translate (0, direction * speed, 0, Space.World);
		} else {
			transform.Translate (direction * speed, 0, 0, Space.World);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag != "grunt")
		{
			direction *= -1;
		}
	}
}

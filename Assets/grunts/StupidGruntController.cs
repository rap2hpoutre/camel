using UnityEngine;
using System.Collections;

public class StupidGruntController : GruntController {

    public GameObject player;

    void FixedUpdate() 
	{
		if (paused || player == null) return;

		Vector3 test = transform.position - player.transform.position;
		float distance = test.magnitude;

		if (distance < 10) {
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
		}

    }
}

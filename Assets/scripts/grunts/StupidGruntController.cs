using UnityEngine;
using System.Collections;

public class StupidGruntController : GruntController {

    public GameObject player;
    private float speed = 0.02f;

    void FixedUpdate() 
	{
        if (paused) return;

		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }
}

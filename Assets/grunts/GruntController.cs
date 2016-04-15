using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour 
{
	public GameObject player;
	public ParticleSystem particle;
	public float speed = 0.02f;

	void Awake()
	{
		speed *= 1 + (0.5f - Random.value);
		player = GameObject.Find("camel");
	}

	void OnDestroy()
	{
		if (!MainController.isQuitting) {
			MainController.IncrementScore (10);
			Instantiate(particle, transform.position, Quaternion.identity);
		}
	}
}

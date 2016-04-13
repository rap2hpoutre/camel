using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour 
{

	public ParticleSystem particle;
	public float speed = 0.02f;

	void Awake()
	{
		speed *= 1 + (0.5f - Random.value);
	}

	void OnDestroy()
	{
		if (!MainController.isQuitting) {
			Instantiate(particle, transform.position, Quaternion.identity);
		}
	}
}

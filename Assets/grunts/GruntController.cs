using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour 
{

	protected bool paused;
	public ParticleSystem particle;
	public float speed = 0.02f;


	void Awake()
	{
		speed *= 1 + (0.5f - Random.value);
	}


	void OnPauseGame()
	{
		paused = true;
	}


	void OnResumeGame()
	{
		paused = false;
	}

	void OnDestroy()
	{
		Instantiate(particle, transform.position, Quaternion.identity);
	}
}

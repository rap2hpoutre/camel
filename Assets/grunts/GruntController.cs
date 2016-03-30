using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour 
{

	protected bool paused;
	public ParticleSystem particle;


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

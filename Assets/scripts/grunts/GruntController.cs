using UnityEngine;
using System.Collections;

public class GruntController : MonoBehaviour 
{

	protected bool paused;

	void OnPauseGame()
	{
		paused = true;
	}


	void OnResumeGame()
	{
		paused = false;
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GateController : MonoBehaviour {

	public string scene;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "camel")
		{
			SceneManager.LoadScene (scene);
		}
	}
}

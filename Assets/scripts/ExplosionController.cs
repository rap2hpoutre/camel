using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	private MainController mainController;

	void Awake()
	{
		mainController = GameObject.Find("Main").GetComponent<MainController>();
		mainController.blinkScreen();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "grunt")
		{
			Destroy(col.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public abstract class BonusController : MonoBehaviour {

	protected CamelController player;

	void Awake()
	{
		player = GameObject.Find("camel").GetComponent<CamelController>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "camel")
		{
			Trigger();
			gameObject.SetActive (false);

		}
	}

	protected abstract void Trigger();
}

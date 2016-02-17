using UnityEngine;
using System.Collections;

public abstract class BonusController : MonoBehaviour {

	protected CamelController player;

	protected SpriteRenderer myRenderer;
	protected CircleCollider2D myCollider;

	void Awake()
	{
		player = GameObject.Find("camel").GetComponent<CamelController>();
		myRenderer = GetComponent<SpriteRenderer> ();
		myCollider = GetComponent<CircleCollider2D> ();
	}

	// Bonus is triggered by collision with player
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "camel")
		{
			Trigger();
			myRenderer.enabled = false;
			myCollider.enabled = false;
		}
	}

	protected abstract void Trigger();
}

using UnityEngine;
using System.Collections;

public class ExplodeBonus : BonusController 
{
	public ExplosionController explosion;

	protected override void Trigger() 
	{
		StartCoroutine(explode(0.1f));
	}

	IEnumerator explode(float seconds)
	{
		ExplosionController e = (ExplosionController)Instantiate (explosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
		Destroy(e.gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class SpeedUpBonusController : BonusController {

	protected override void Trigger() 
	{
		StartCoroutine(speedUp(1));
	}

	IEnumerator speedUp(float seconds)
	{
		float originalSpeed = (float)player.speed;
		player.speed *= 1.5f;
		yield return new WaitForSeconds(seconds);
		player.speed = originalSpeed;
		Destroy(gameObject);
	}


}

using UnityEngine;
using System.Collections;

public class SpeedFireBonusController : BonusController {

	protected override void Trigger() 
	{
		StartCoroutine(speedUpFire(2));
	}

	IEnumerator speedUpFire(float seconds)
	{
		float originalSpeed = (float)player.cooldown;
		player.cooldown /= 3f;
		yield return new WaitForSeconds(seconds);
		player.cooldown = originalSpeed;
		Destroy(gameObject);
	}
}

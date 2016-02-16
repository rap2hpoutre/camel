using UnityEngine;
using System.Collections;

public class SpeedUpBonusController : BonusController {

	protected override void Trigger() 
	{
		Debug.Log ("Bonus triggered");
		Debug.Log(player);

		StartCoroutine(speedUp(1));
	}

	IEnumerator speedUp(float seconds)
	{
		float originalSpeed = (float)player.speed;
		player.speed *= 1.5f;
		Debug.Log(player.speed);
		yield return new WaitForSeconds(seconds);
		player.speed = originalSpeed;
		Debug.Log(player.speed);
		Destroy(gameObject);
	}


}

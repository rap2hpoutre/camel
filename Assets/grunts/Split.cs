using UnityEngine;
using System.Collections;

public class Split : MonoBehaviour {

	public GameObject newGrunt;
	
	void OnDestroy()
	{
		if (!MainController.isQuitting) {
			Instantiate(newGrunt, new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z), Quaternion.identity);
			Instantiate(newGrunt, new Vector3(transform.position.x+0.5f, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(newGrunt, new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate(newGrunt, new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z), Quaternion.identity);
		}
	}
}

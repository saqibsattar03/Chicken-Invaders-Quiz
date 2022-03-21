using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth :Pickup
{
	public override void PickMeUp()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddHEalth();
		Destroy(gameObject);
	}

	void DestroyHealth()
	{
		if (gameObject.transform.position.y < 3)
		{
			Destroy(gameObject);
		}
	}

}

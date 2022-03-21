using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : Pickup
{
	public override void PickMeUp()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddLife();
		Destroy(gameObject);
	}

	void DestroyLife() 
	{
		if (gameObject.transform.position.y < 3) 
		{
			Destroy(gameObject);
		}
	}

}

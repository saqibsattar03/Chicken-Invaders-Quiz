using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public int scoreValue;

    private float leftLimit = -8f;
    private float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        DestroyShip();
    }

    void MoveShip() 
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

    }

    void DestroyShip() 
    {
        if (transform.position.x <= leftLimit) 
        {
            Destroy(gameObject);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}
}

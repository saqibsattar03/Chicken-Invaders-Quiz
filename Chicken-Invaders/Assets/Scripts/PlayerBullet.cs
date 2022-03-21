using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        DestroyBullet();
    }

    void FireBullet()
    {
        transform.Translate(Vector2.up * Time.deltaTime * bulletSpeed);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            // kill the enemy
            collision.gameObject.GetComponent<EnemyController>().Kill();

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }

    void DestroyBullet() 
    {
        if (transform.position.y > 10.0f) 
        {
            Destroy(gameObject);
        }
    }
}

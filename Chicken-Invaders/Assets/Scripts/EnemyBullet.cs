using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }
    void FireBullet()
    {
        transform.Translate(Vector2.down * Time.deltaTime * bulletSpeed);
    }

    void DestroyBullet()
    {
        if (transform.position.y < 10.0f)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBlock : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shipPefab;

    private Vector3 hMoveDistance = new Vector3(0.1f,0,0);
    private Vector3 vMoveDistance = new Vector3(0,0.01f,0);
    private Vector3 shipSpawnPos = new Vector3(3.72f, 5, 0);

    private float leftLimit = 0.95f;
    private float rightLimit = 1.0f;
    private float shipMoveSpeed = 0.02f;

    private bool isMovingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private float shootTimer = 3f;
    private float shotTime = 3f;

    private float shipTimer = 1.0f;
    private float minTime = 15.0f;
    private float maxTime = 60.0f;

    private float maxMoveSpeed = 0.2f;
    public static List<GameObject> allEnemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            allEnemies.Add(go); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0) 
        {
            MoveEnemies();
        }
        moveTimer -= Time.deltaTime;

        if (shootTimer <= 0) 
        {
            Shoot();
        }

        shootTimer -= Time.deltaTime;

        if (shipTimer <= 0) 
        {
            SpawnShip();
        }
        shipTimer -= Time.deltaTime;
    }

    void MoveEnemies() 
    {
        int hitMax = 0;

        //Moving Enemies 

        if(allEnemies.Count > 0) 
        {
            for (int i = 0; i < allEnemies.Count; i++) 
            {
                if (isMovingRight)
                    allEnemies[i].transform.position += hMoveDistance;
                else
                    allEnemies[i].transform.position -= hMoveDistance;

                if (allEnemies[i].transform.position.x > rightLimit || allEnemies[i].transform.position.x < leftLimit) 
                {
                    hitMax++;
                }
            }

            if (hitMax > 0) 
            {
                for (int i = 0; i < allEnemies.Count; i++) 
                {
                    allEnemies[i].transform.position -= vMoveDistance;
                }
                isMovingRight = !isMovingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    private float GetMoveSpeed() 
    {
        float f = allEnemies.Count * moveTime;
        if (f < maxMoveSpeed)
        {
            return maxMoveSpeed;
        }
        else
        {
            return f;
        }
    }

    private void Shoot() 
    {
        Vector2 pos = allEnemies[Random.Range(0, allEnemies.Count)].transform.position;
        Instantiate(bulletPrefab,pos,Quaternion.identity);
        shootTimer = shotTime;
    }

    private void SpawnShip() 
    {
        Instantiate(shipPefab, shipSpawnPos, Quaternion.identity);
        shipTimer = Random.Range(minTime, maxTime);
    }
}

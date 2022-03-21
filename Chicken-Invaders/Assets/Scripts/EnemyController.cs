using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int scoreValue;
    public float delay = 0;

    public GameObject[] bonusPrefab;

    public GameObject explosionPrefab;

    public void Kill() 
    {
        GameManager.UpdateScore(scoreValue); 
        EnemiesBlock.allEnemies.Remove(gameObject);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        int randomIndex = Random.Range(0, bonusPrefab.Length);
        Instantiate(bonusPrefab[randomIndex], transform.position, Quaternion.identity);


        if (EnemiesBlock.allEnemies.Count == 0) 
        {
            GameManager.SpawnNewWave();
        }
        Destroy(gameObject);
    }
}

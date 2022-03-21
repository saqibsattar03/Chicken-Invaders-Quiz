using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStat playerStat; 
    public GameObject bulletPrefab;

    private float leftLimit;
    private float rightLimit;
    private bool isShooting;

    private Vector2 offScreenPos = new Vector2(0, -200);
    private Vector2 startPos = new Vector2(0, -4);


    // Start is called before the first frame update
    void Start()
    {
        playerStat.currentHealth = playerStat.maxHEalth;
        playerStat.currentLives = playerStat.maxLives;
        rightLimit = 8.0f;
        leftLimit = -8.0f;
        transform.position = startPos;

        GameManager.UpdateHealthBar(playerStat.currentHealth);
        GameManager.UpdateLives(playerStat.currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        MoveRight();

        if (Input.GetKey(KeyCode.Space) && !isShooting) 
        {
            StartCoroutine(Shoot());
        }
    }

    void MoveLeft() 
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftLimit) 
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerStat.playerSpeed);
        }
    }

    void MoveRight() 
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightLimit) 
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerStat.playerSpeed);
        }
    }

    private IEnumerator Shoot () 
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playerStat.fireSpeed);
        isShooting = false;
    }

     

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Playr killed");
            TakeDemage();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BonusLife"))
        {
            AddLife();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BonusHealth")) 
        {
            AddHEalth();
            Destroy(collision.gameObject);
        }
		
	}

    void TakeDemage() 
    {
        playerStat.currentHealth--;
        GameManager.UpdateHealthBar(playerStat.currentHealth);
        if (playerStat.currentHealth <= 0) 
        {
            playerStat.currentLives--;
            GameManager.UpdateLives(playerStat.currentLives);
            if (playerStat.currentLives <= 0)
            {
                Debug.Log("game over");
                //Game over
                GameManager.GameOver();
                FindObjectOfType<GameManager>().panel.SetActive(true);
            }
            else 
            {
                // Respawn player

                StartCoroutine(Reswapm());
            }
        }
    }

    private IEnumerator Reswapm() 
    {
        transform.position = offScreenPos;
        yield return new WaitForSeconds(2);
        playerStat.currentHealth = playerStat.maxHEalth;
        transform.position = startPos;
    }

    public void AddHEalth() 
    {
        if (playerStat.currentHealth == playerStat.maxHEalth) 
        {
            GameManager.UpdateScore(250);
        }
		else 
        {
            playerStat.currentHealth++;
            GameManager.UpdateHealthBar(playerStat.currentHealth);
        }
    }

    public void AddLife() 
    {

        if (playerStat.currentLives == playerStat.maxLives)
        {
            GameManager.UpdateScore(1000);
        }
        else
        {
            playerStat.currentHealth++;
            GameManager.UpdateHealthBar(playerStat.currentLives  );
        }
    }
}

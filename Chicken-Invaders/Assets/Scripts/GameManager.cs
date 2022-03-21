using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject[] allEnemies;
	public GameObject panel;
	private GameObject currentSet;
	private Vector2 spawnPos = new Vector2(0, 3f); 

	public TextMeshProUGUI scoreText;
	private int score;

	public Image[] lifeSprites;
	public Image healthBar;

	public Sprite[] healthBars;

	private static GameManager instance;
	private Color32 active = new Color(1,1,1,1);
	private Color32 inactive = new Color(1,1,1,0.25f);

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else 
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		SpawnNewWave();
	}

	public static void UpdateLives(int l) 
	{
		foreach(Image i in instance.lifeSprites) 
		{
			i.color = instance.inactive;
			for (int ii = 0; ii < l; ii++) 
			{
				instance.lifeSprites[ii].color = instance.active;
			}
		}

	}

	public static void UpdateHealthBar(int h)
	{
		instance.healthBar.sprite = instance.healthBars[h];

	}

	public static void UpdateScore(int s)
	{
		instance.score += s;
		instance.scoreText.text = instance.score.ToString("000");
	}

	public static void SpawnNewWave() 
	{
		instance.StartCoroutine(instance.SpawnWave());
	}

	private IEnumerator SpawnWave() 
	{
		if (currentSet != null) 
		{
			Destroy(currentSet);
		}
		yield return new WaitForSeconds(1);

		currentSet = Instantiate(allEnemies[Random.Range(0, allEnemies.Length)], spawnPos, Quaternion.identity);
	}
	public static void GameOver()
	{
		Time.timeScale = 0;
	}

	public static void Restart()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

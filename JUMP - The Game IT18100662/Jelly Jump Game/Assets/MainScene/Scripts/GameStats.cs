using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStats : MonoBehaviour{



	public Player player;
	public Text scoreText;
	public Text highScore;
	public GameObject platformHolder;
	public int platChildren;

	public int totalLives = 3;
	public Text livesText,carrotText;

	public GameObject gameOver;

	int currentLife = 1;
	int carrot = 0;
	void Awake(){

		currentLife = totalLives;
		holderTransform = platformHolder.GetComponent<Transform>();
		if (gameOver)
			gameOver.SetActive(false);
	}

	// Use this for initialization
	void Start (){


		Coroutine c = StartCoroutine(scoreUpdater());
		highScore.text = "HighScore "+PlayerPrefs.GetInt("HighScore");
		livesText.text = currentLife.ToString();
		carrotText.text = carrot.ToString();

	}
	public void addCarrot()
	{
		carrot++;
		carrotText.text = carrot.ToString();

	}
	void GameOver()
    {
		gameOver.SetActive(true);
    }

	public void replayButton()
    {

		PlayerPrefs.SetInt("HighScore", Math.Max(i, PlayerPrefs.GetInt("HighScore")));
		SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
	}
	public void takeLife()
	{
		if (currentLife <= 1)
		{

			GameOver();
		}
		else
		{
			currentLife--;
			livesText.text = currentLife.ToString();
			player.Reset();
		}
	}
	int i = 0;
	IEnumerator scoreUpdater(){
		
		

		while (player.alive())
		{
            yield return new WaitForSeconds(1.0f);
            scoreText.text = "Score " + i;
            if (!player.alive())
            {
                break;
            }
            ++i;

        }





	}
	// Update is called once per frame
	void Update () {
		platChildren = holderTransform.childCount;


		if (Input.GetKeyDown(KeyCode.Escape)){
			//TODO cleanup here
			Application.Quit();
		}
		
		
		
		
	}
	
	private Transform holderTransform;

}

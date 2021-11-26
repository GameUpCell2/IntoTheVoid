using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;
public class GameManager : MonoBehaviour
{   
    public static GameManager Instance { set; get;}
    private int gameLevel = 0;
    public int GameLevel {get{ return gameLevel;}}
    private int LEVEL_UP_MARGIN = 100;

    public GameObject gameOverPanel;

    public bool isDead = false;
    

    public Text scoreText;
    public Text highScoreText;
    public Text gameOverScoreText;
    public int gameScore = 0;
    private int highscore;

    private void Awake()
    {
        if (Instance != null)
		{
			Destroy(gameObject);
		} else
		{
			Instance = this;
		}  
    }


    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        gameScore += score;
        if(scoreText != null)
        {
            scoreText.text = gameScore.ToString();
        }
        
        if(gameScore % LEVEL_UP_MARGIN == 0 && gameScore > 0)
        {
            gameLevel += 1;
            LEVEL_UP_MARGIN *= 2;
        }
        if(gameScore > highscore)
        {
            highscore = gameScore;
        }

        highScoreText.text = highscore.ToString();
    }
    
    public void GameOver()
    {
        isDead = true;
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = gameScore.ToString();
        ObstacleSpawn.Instance.isSpawning = false;
        gameOverPanel.SetActive(true);
        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        if(highscore > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        
    }

}

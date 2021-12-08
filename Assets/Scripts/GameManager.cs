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
    private int LEVEL_UP_MARGIN = 50;

    public GameObject gameOverPanel, useReviveAdPanel;

    public bool isDead = false;
    public bool IsMute = false;    
    public bool IsPaused = false;    
    
    public Text scoreText;
    public Text highScoreText, newHighScore;
    public Text gameOverScoreText;
    public int gameScore = 0;
    private int highscore;

    // HUD
    public GameObject HUDPanel;
    public Slider progressSlider;

    // BackGround Images
    public Sprite[] bgImages;
    public Image bgPanel;
    public Animator bgAnim;

    // Post Game Play
    public bool useReviveAd = true; // Initially hold true
    
    // PowerUps and Specials
    public bool ClearAllObstacles;
    public bool ShieldPlayer;
    public bool MultGun;
    public float powerupLength = 5f;

    // Player Lives
    private int noLives = 4;
    public int NoLives{get{return noLives;}}
    public GameObject[] noLivesIndicators;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        IsMute = PlayerPrefs.GetInt("IsMute",0)==1;
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        gameScore += score;
        progressSlider.value = gameScore % LEVEL_UP_MARGIN;
        if(scoreText != null)
        {
            scoreText.text = gameScore.ToString();
        }
        
        if(gameScore % LEVEL_UP_MARGIN == 0 && gameScore > 0)
        {   
            progressSlider.value = 0;
            MyAudioManager.Instance.Play("levelUp");
            SwitchBackground();
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
        HUDPanel.SetActive(false);
        gameOverScoreText.text = gameScore.ToString();
        ObstacleSpawn.Instance.isSpawning = false;
        gameOverPanel.SetActive(true);
        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        if(highscore > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", highscore);
            newHighScore.gameObject.SetActive(true);
            MyAudioManager.Instance.Play("win");
        }
        else
        {
            MyAudioManager.Instance.Play("lose");
        }
        
    }

    public void SwitchBackground()
    {
        // Get Random BgImage
        int randIndx = Random.Range (0, bgImages.Length-1);
        bgAnim.SetTrigger("BgChange");
        bgPanel.sprite = bgImages[randIndx];

    }

    public void UseReviveAd(bool play)
    {
        if(play)
        {
            // Play Unity Ads and Continue GamePlay
            StartCoroutine(EnablePowerUp(ClearAllObstacles));
            StartCoroutine(EnablePowerUp(ShieldPlayer));
        }

        else
        {
            // Show Proper GameOver Menu
            useReviveAdPanel.SetActive(false);
            GameOver();
        }
    }

    public void OnDeath()
    {
        useReviveAdPanel.SetActive(true);

    }

    public void HitObstacle()
    {
        noLivesIndicators[noLives-1].SetActive(false);
        noLives -= 1;
        if(noLives <= 0)
        {
            OnDeath();
        }
    }

    public void EnableClearAllObstacles()
    {

    }

    IEnumerator EnablePowerUp(bool powerup)
    {
        powerup = true;
        yield return new WaitForSeconds(powerupLength);
        powerup = false;
    }
}

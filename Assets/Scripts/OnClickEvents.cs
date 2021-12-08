using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class OnClickEvents : MonoBehaviour
{
    public Text nameField; 

    public void RestartGamePlay()
    {
        // Restarting Scene
        SceneManager.LoadScene("Game");
    }

    public void LoadHomePage()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseResumeGame()
    {
        if(GameManager.Instance.IsPaused)
        {
            GameManager.Instance.IsPaused = false;
            Time.timeScale = 1;
        }
        else
        {
            GameManager.Instance.IsPaused = true;
            Time.timeScale = 0;
        }
    }

    public void ToggleMute()
    {
        if(GameManager.Instance.IsMute)
        {
            GameManager.Instance.IsMute = false;
            PlayerPrefs.SetInt("IsMute",0);
        }
        else
        {
            GameManager.Instance.IsMute = true;
            PlayerPrefs.SetInt("IsMute",1);
        }
    }

    public void SubmitScore()
    {

        HighScores.UploadScore(nameField.text, PlayerPrefs.GetInt("Highscore",0));
    }
}

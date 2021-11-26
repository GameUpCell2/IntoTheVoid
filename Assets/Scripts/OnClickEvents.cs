using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnClickEvents : MonoBehaviour
{

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
        SceneManager.LoadScene("Workshop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

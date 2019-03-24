using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        highscoreText.text = "Highscore: " + GameMaster.instance.highScore.ToString("0");
    }

    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
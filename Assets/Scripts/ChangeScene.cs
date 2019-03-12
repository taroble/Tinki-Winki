﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartMain()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartMenu()
    {
    	SceneManager.LoadScene("Menu");
    }
}
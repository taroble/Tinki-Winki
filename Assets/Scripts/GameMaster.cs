using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [HideInInspector]
    public int highScore = 0;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public bool CheckIfHighscore(int scoreToCheck)
    {
        if (scoreToCheck > highScore)
        {
            highScore = scoreToCheck;
            return true;
        }
        else
        {
            return false;
        }
    }
}
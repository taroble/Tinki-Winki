using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timeCount;
    [HideInInspector]
    public int score;
    public Text text;
    [HideInInspector]
    public bool gameover;

    void Start()
    {
        timeCount = 0f;
    }

    void Update()
    {
        if (!gameover)
        {
            gameRunning();
        }
        else
        {
            // don't update timer
        }
    }

    void gameRunning()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= 1)
        {
            timeCount -= 1;
            score++;
        }
        text.text = score.ToString("0000");
    }
}
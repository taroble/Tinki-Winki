using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	float timeCount;
	public Text text;
    private bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover) {
            gameRunning();
        }
        else {
            // don't update timer
        }
    }

    void gameRunning(){
        timeCount += Time.deltaTime;
        text.text = timeCount.ToString("0000");
    }
}

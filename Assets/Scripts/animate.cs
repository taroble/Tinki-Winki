using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    
	SpriteRenderer sr;
	public Sprite[] cycle;

    int currentrunFrame = 0;
   	Sprite staticSprite;
   	public int fps;

   	float runFrameTime;
	float runFrameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        runFrameTime = 1 / (float)fps;
        sr = GetComponent<SpriteRenderer>();

        staticSprite = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (runFrameTimer < runFrameTime) {
            runFrameTimer += Time.deltaTime;
        }
        else {
            sr.sprite = cycle[currentrunFrame];
            currentrunFrame = (currentrunFrame + 1) % (cycle.Length);
            runFrameTimer = 0;
        }
    }
}

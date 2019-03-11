using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	float timeCount;
	public Text text;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        text.text = timeCount.ToString("###");
    }
}

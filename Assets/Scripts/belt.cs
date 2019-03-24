using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class belt : MonoBehaviour
{
	float timeCount;
	public float seconds = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;

    }

    // Update is called once per frame
    void Update()
    {

    	timeCount += Time.deltaTime;

    	if (timeCount >= seconds)
        {
            timeCount = timeCount - seconds;
            if (transform.position.y == 0f)
            {
            	transform.position = new Vector2(transform.position.x, 0.4f);
            }
            else
            {
            	transform.position = new Vector2(transform.position.x, 0f);
            }
        }
    }

}

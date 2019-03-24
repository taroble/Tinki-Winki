using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapSpawner : MonoBehaviour
{
    public GameObject[] scraps;
	// public float minSpawnTimer;
	// public float maxSpawnTimer;
	float spawnTimer;
	int pipeNum, randUpgrade, randScrap;
	float timeCount, randNum;
	private bool gameover;
	int index;
	public float x1,x2;


	// Use this for initialization
	void Start () {
		spawnTimer = Random.Range(0f, 2f);
		timeCount = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		spawnTimer -= Time.deltaTime;
		timeCount += Time.deltaTime;

		randNum = Random.Range(0f, 100f);
		pipeNum = Random.Range(0, 2);


		if (randNum <= 5f)
		{
			index = 3;
		}
		else if (randNum > 5f && randNum <= 10f)
		{
			index = 4;
		}
		else if (randNum > 10f && randNum <= 15f)
		{
			index = 5;
		}
		else
		{
			randScrap = Random.Range(0, 3);
			index = randScrap;
		}
		
		if (timeCount < 30f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -2;
		}
		else if (timeCount > 30f && timeCount < 60f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -3;
			
		}
		else if (timeCount > 60f && timeCount < 90f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -4;
			
		}

		if (spawnTimer <= 0)
		{
			if (timeCount < 30f){
				spawnTimer = Random.Range(2f,3f);
			}
			else {
				spawnTimer = Random.Range(1f,2f);
			}

			if (pipeNum == 0)
			{
				Instantiate(scraps[index], new Vector2(x1, 6f), Quaternion.identity);
			}
			else if (pipeNum == 1)
			{
				Instantiate(scraps[index], new Vector2(x2, 6f), Quaternion.identity);
			}
			

			//Instantiate(scraps[index]);

			
			// if (pipeNum == 0)
			// {
			// 	Instantiate(scraps[index], new Vector2(-4.5f, 6f), Quaternion.identity);
			// }
			// else if (pipeNum == 2)
			// {
			// 	Instantiate(scraps[index], new Vector2(-1.5f, 6f), Quaternion.identity);
			// }
			// else if (pipeNum == 3)
			// {
			// 	Instantiate(scraps[index], new Vector2(1.5f, 6f), Quaternion.identity);
			// }
			// else
			// {
			// 	Instantiate(scraps[index], new Vector2(4.5f, 6f), Quaternion.identity);
			// }
		}

		
	}



}

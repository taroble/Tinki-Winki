using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapSpawner : MonoBehaviour
{
    public GameObject[] scraps;
	public float minSpawnTimer;
	public float maxSpawnTimer;
	float spawnTimer;
	int index;
	float timeCount;

	// Use this for initialization
	void Start () {
		spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
		timeCount = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		index = Random.Range(0, scraps.Length);

		timeCount += Time.deltaTime;

		
		if (timeCount < 30f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -1;
		}
		else if (timeCount == 30f)
		{
			minSpawnTimer -= 2;
			maxSpawnTimer -= 2;
		}
		else if (timeCount > 30f && timeCount < 60f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -2;
			
		}
		else if (timeCount == 60f)
		{
			minSpawnTimer -= 2;
			maxSpawnTimer -= 2;
		}
		else if (timeCount > 60f && timeCount < 90f)
		{
			scraps[index].GetComponent<scrap>().ySpeed = -3;
			
		}

		if (spawnTimer <= 0) {
			spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
			Instantiate(scraps[index]);
		}
	}
}

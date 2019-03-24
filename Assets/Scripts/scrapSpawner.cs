using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapSpawner : MonoBehaviour
{
    public float spawnTimerLengthMin;
    public float spawnTimerLengthMax;
    float spawnTimer;

    public GameObject scrapPrefab;
    public GameObject[] scrapSpawners;



    void Start()
    {
        spawnTimer = Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(spawnTimerLengthMin, spawnTimerLengthMax);
            SpawnScrap();
        }
    }



    void SpawnScrap()
    {
        int firstPipeIndex = Random.Range(0, scrapSpawners.Length - 1);
        Instantiate(scrapPrefab, new Vector2(scrapSpawners[firstPipeIndex].transform.position.x, scrapSpawners[firstPipeIndex].transform.position.y), Quaternion.identity);

        //Roll to spawn a second scrap (10% chance to move on)
        if (Random.Range(0f, 100f) > 10) return;

        int secondPipeIndex = Random.Range(0, scrapSpawners.Length);
        while (secondPipeIndex == firstPipeIndex) secondPipeIndex = Random.Range(0, scrapSpawners.Length - 1);
        Instantiate(scrapPrefab, new Vector2(scrapSpawners[secondPipeIndex].transform.position.x, scrapSpawners[secondPipeIndex].transform.position.y), Quaternion.identity);

        //Roll to spawn a third scrap (another 10% chance on top of the above 10% chance)
        if (Random.Range(0f, 100f) > 10) return;

        int thirdPipeIndex = Random.Range(0, scrapSpawners.Length);
        while (thirdPipeIndex == firstPipeIndex || thirdPipeIndex == secondPipeIndex) secondPipeIndex = Random.Range(0, scrapSpawners.Length - 1);
        Instantiate(scrapPrefab, new Vector2(scrapSpawners[thirdPipeIndex].transform.position.x, scrapSpawners[thirdPipeIndex].transform.position.y), Quaternion.identity);
    }
}
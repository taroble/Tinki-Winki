using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    public float ySpeed;
    public Sprite[] scrapSprites;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = scrapSprites[Random.Range(0, scrapSprites.Length - 1)];
    }

    void Update()
    {
        Vector2 moveAmount = new Vector2();
        moveAmount.x = 0;
        moveAmount.y = ySpeed;
        transform.Translate(moveAmount * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private SpriteRenderer sr;
    private Collider2D coll;
    public Sprite playerSprite, hurtSprite, hurt1Sprite, deadSprite;
    public Sprite playerSprite1, hurtSprite1, hurt1Sprite1;
    public Image health;
    public Sprite fullHealth, halfHealth, lowHealth, noHealth;
    float timeCount;
    public float seconds = 0.1f;
    public GameObject bomb, razor, explosion;
    float razorTimer = 0f, explosionTimer = 0f;
    GameObject[] gameObjects;
    AudioSource audioS;
    public AudioClip[] sounds;
    public Timer timerObject;

    public GameObject gameOverCanvas;
    public Text gameOverScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = playerSprite;
        health.sprite = fullHealth;

        coll = GetComponent<Collider2D>();
        timeCount = 0;

        audioS = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (sr.sprite != deadSprite)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
        else
        {
            coll.enabled = false;
        }

        if (timeCount >= seconds)
        {
            timeCount = timeCount - seconds;
            if (sr.sprite == playerSprite || sr.sprite == playerSprite1)
            {
                if (sr.sprite == playerSprite)
                {
                    sr.sprite = playerSprite1;
                }
                else
                {
                    sr.sprite = playerSprite;
                }
            }
            else if (sr.sprite == hurtSprite || sr.sprite == hurtSprite1)
            {
                if (sr.sprite == hurtSprite)
                {
                    sr.sprite = hurtSprite1;
                }
                else
                {
                    sr.sprite = hurtSprite;
                }
            }
            else if (sr.sprite == hurt1Sprite || sr.sprite == hurt1Sprite1)
            {
                if (sr.sprite == hurt1Sprite)
                {
                    sr.sprite = hurt1Sprite1;
                }
                else
                {
                    sr.sprite = hurt1Sprite;
                }
            }
            if (explosion.activeSelf == true)
            {
                explosionTimer += Time.deltaTime;
                if (explosionTimer > 0.2f)
                {
                    explosion.SetActive(false);
                }
            }

            if (bomb.activeSelf == true)
            {
                if (Input.GetMouseButton(0))
                {
                    DestroyAllObjects();
                    bomb.SetActive(false);
                    playsound(4);
                    explosion.SetActive(true);
                }
            }

            if (razor.activeSelf == true)
            {
                razorTimer += Time.deltaTime;
                if (razorTimer > 0.5f)
                {
                    razor.SetActive(false);
                }
            }
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Battery")
        {
            Destroy(col.gameObject);
            playsound(5);
            if (sr.sprite == hurtSprite || sr.sprite == hurtSprite1)
            {
                sr.sprite = playerSprite;
                health.sprite = fullHealth;
            }
            else if (sr.sprite == hurt1Sprite || sr.sprite == hurt1Sprite1)
            {
                sr.sprite = hurtSprite;
                health.sprite = halfHealth;
            }
        }
        else if (col.gameObject.tag == "Bomb")
        {
            Destroy(col.gameObject);
            bomb.SetActive(true);
        }
        else if (col.gameObject.tag == "Razor")
        {
            Destroy(col.gameObject);
            razor.SetActive(true);
            razorTimer = 0f;
            playsound(3);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            if (razor.activeSelf == true)
            {
                // take no damage
                playsound(3);
            }
            else
            {
                if (sr.sprite == playerSprite || sr.sprite == playerSprite1)
                {
                    sr.sprite = hurtSprite;
                    health.sprite = halfHealth;
                    playsound(0);
                }
                else if (sr.sprite == hurtSprite || sr.sprite == hurtSprite1)
                {
                    sr.sprite = hurt1Sprite;
                    health.sprite = lowHealth;
                    playsound(1);
                }
                else if (sr.sprite == hurt1Sprite || sr.sprite == hurt1Sprite1)
                {
                    sr.sprite = deadSprite;
                    health.sprite = noHealth;
                    playsound(2);
                    GameOver();
                }
            }
        }
    }

    void DestroyAllObjects()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    void playsound(int index)
    {
        audioS.clip = sounds[index];
        audioS.Play();
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Cursor.visible = true;
        timerObject.gameover = true;

        if (GameMaster.instance.CheckIfHighscore(timerObject.score))
        {
            gameOverScoreText.text = "New Highscore! " + timerObject.score.ToString("0");
        }
        else
        {
            gameOverScoreText.text = "Score: " + timerObject.score.ToString("0");
        }
    }
}
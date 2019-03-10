using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite playerSprite, hurtSprite, hurt1Sprite, deadSprite;

    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        playerSprite = Resources.Load<Sprite>("Player_placeholder");
        hurtSprite = Resources.Load<Sprite>("hurt");
        hurt1Sprite = Resources.Load<Sprite>("hurt1");
        deadSprite = Resources.Load<Sprite>("dead");
        rend.sprite = playerSprite;
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag.Equals ("Enemy"))
        {
            Destroy (col.gameObject);
            if (rend.sprite == playerSprite)
                rend.sprite = hurtSprite;
            else if (rend.sprite == hurtSprite)
                rend.sprite = hurt1Sprite;
            else if (rend.sprite == hurt1Sprite)
                rend.sprite = deadSprite;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag.Equals ("Upgrade"))
        {
            Destroy(col.gameObject);
        }
    }
}

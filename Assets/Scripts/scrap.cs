using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrap : MonoBehaviour
{
    public float ySpeed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, ySpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -6) {
			Destroy(gameObject);
		}
	}

}

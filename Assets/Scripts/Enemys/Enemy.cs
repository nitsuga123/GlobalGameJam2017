﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public static float speed = 100;
    
    private Rigidbody2D rb;

	//Unity functions

	void Awake ()
    {
        rb=GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        rb.velocity = new Vector3(-speed * Time.deltaTime, 0, 0);
	}
}

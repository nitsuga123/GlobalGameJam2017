﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private float speed;
    
    private Rigidbody2D rb;

	// Use this for initialization
	void Awake () {

        rb=GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector3(-speed * Time.deltaTime, 0, 0);


	}






}

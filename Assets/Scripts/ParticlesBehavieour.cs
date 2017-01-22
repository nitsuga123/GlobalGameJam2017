using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehavieour : MonoBehaviour {

    private ParticleSystem particule;
    private WaveMovement particleScripte;
    private Vector3 startPosition;

	// Use this for initialization
	void Awake () {
        particule = GetComponentInChildren<ParticleSystem>();
        particleScripte = GetComponent<WaveMovement>();
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
            {
            particleScripte.enabled = true;
        }
	}
}

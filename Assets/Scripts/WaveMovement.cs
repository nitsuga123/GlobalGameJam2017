using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {
	
	public float waveSpeed;
	public float waveScale;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x + waveSpeed, gameObject.transform.position.y,  gameObject.transform.position.z);

		if (gameObject.transform.localScale.y < 2) {
			gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x, gameObject.transform.localScale.y + waveScale,  gameObject.transform.localScale.z);
		}


	}
}

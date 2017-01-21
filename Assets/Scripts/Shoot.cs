using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input .GetKey(KeyCode.R))
        {
            Attacks.Instance.AttackRed();
        }

        if (Input.GetKey(KeyCode.B))
        {
            Attacks.Instance.AttackBlue();
        }

        if (Input.GetKey(KeyCode.Y))
        {
            Attacks.Instance.AttackYellow();
        }
    }
}

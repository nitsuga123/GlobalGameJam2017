using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;

        if (time > 0.7f)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                Attacks.Instance.AttackRed();
                time = 0;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Attacks.Instance.AttackBlue();
                time = 0;
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                Attacks.Instance.AttackYellow();
                time = 0;
            }
        }
    }
}

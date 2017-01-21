using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    private Animator anim;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.B))  || (Input.GetKeyDown(KeyCode.Y)))
        {
            anim.SetInteger("Action",1);
        }
        else
        {
            anim.SetInteger("Action", 0);
        }

    }
}

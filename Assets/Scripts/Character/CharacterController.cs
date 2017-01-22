using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    bool Attack=true;

    public static bool hit=true;

    public static bool die=true;
    
    public static Animator anim;

    //Unity functions

	void Awake () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.B))  || (Input.GetKeyDown(KeyCode.Y)))
        {
            anim.SetInteger("Action",1);
            Attack = false;
        }
        else
        {
            Attack = true;
        }
        if(Attack && hit && die)
        {
            anim.SetInteger("Action", 0);
        }

    }
}

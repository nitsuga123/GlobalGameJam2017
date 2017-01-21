using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour {

    public static Attacks instance;
    public static Attacks Instance
    {
        get
        {
            return instance;
        }
    }

    [HideInInspector]
    public float waveSpeed = 0.5f;

    public GameObject waveRed;
    public GameObject waveBlue;
    public GameObject waveYellow;


    
    private bool attackingRed = false;
    private bool attackingYellow = false;
    private bool attackingBlue = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(attackingRed)
        {
            MoveRed();
        }

        if (attackingYellow)
        {
            MoveYellow();
        }

        if (attackingBlue)
        {
            MoveBlue();
        }
    }

    public void AttackRed()
    {
        attackingRed = true;
    }

    private void MoveRed()
    {
        waveRed.transform.position = new Vector3(waveRed.transform.position.x + waveSpeed, waveRed.transform.position.y, waveRed.transform.position.z);
    }

    public void EndRed()
    {
        attackingRed = false;
    }

    public void AttackYellow()
    {
        attackingYellow = true;
    }

    private void MoveYellow()
    {
        waveYellow.transform.position = new Vector3(waveYellow.transform.position.x + waveSpeed, waveYellow.transform.position.y, waveYellow.transform.position.z);
    }

    public void EndYellow()
    {
        attackingYellow = false;
    }

    public void AttackBlue()
    {
        attackingBlue = true;
    }

    private void MoveBlue()
    {
        waveBlue.transform.position = new Vector3(waveBlue.transform.position.x + waveSpeed, waveBlue.transform.position.y, waveBlue.transform.position.z);
    }

    public void EndBlue()
    {
        attackingBlue = false;
    } 
}

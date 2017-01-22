using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private static Spawn instance;
    public static Spawn Instance
    {
        get
        {
            return instance;
        }
    }

    public float timeleft;
    private float i;

    //Unity functions

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if (i < timeleft)
        {
            i+=Time.deltaTime;
        }
        else
        {
            Pool_Enemys.pool_enemys.ObtainBat();
            i = 0;
        }
	}

    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Red"))
        {
            Pool_Enemys.pool_enemys.DesactiveBat(collider);
        }
        if (collider.gameObject.CompareTag("Blue"))
        {
            Pool_Enemys.pool_enemys.DesactiveBat(collider);
        }
        if (collider.gameObject.CompareTag("Yellow"))
        {
           
            Pool_Enemys.pool_enemys.DesactiveBat(collider);
        }
    }
}
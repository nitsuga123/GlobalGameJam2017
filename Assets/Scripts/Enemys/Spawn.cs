using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private float timeleft;

    private float i;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        if(i < timeleft)
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

        if (collider.gameObject.CompareTag("Bat"))
        {
            Debug.Log("rio¿p");
            Pool_Enemys.pool_enemys.DesactiveBat(collider);
        }

    }

    

}

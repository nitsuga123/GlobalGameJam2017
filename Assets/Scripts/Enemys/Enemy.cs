using System.Collections;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        //If this bat strikes an approporiate wave
        if (other.gameObject.tag == this.gameObject.tag) 
        {
            Die();
        }

        print(other.gameObject.transform.tag);

        //print(this.transform.tag);

    }

    void Die()
    {
        Destroy(this.gameObject);
        print("Dying");
    }
}

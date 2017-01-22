using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private float time;

	[SerializeField]
	private AudioSource disparo1;

	[SerializeField]
	private AudioSource disparo2;

	[SerializeField]
	private AudioSource disparo3;

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
				StartCoroutine (Disparo1 ());
                AttackBehaviour.Instance.AttackRed();
                time = 0;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
				StartCoroutine (Disparo2());
                AttackBehaviour.Instance.AttackBlue();
                time = 0;
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
				StartCoroutine (Disparo3 ());
                AttackBehaviour.Instance.AttackYellow();
                time = 0;
            }
        }
    }

	IEnumerator Disparo1 (){
		yield return new WaitForSeconds (0.35f);
		disparo1.Play ();
	}
	IEnumerator Disparo2 (){
		yield return new WaitForSeconds (0.35f);
		disparo2.Play ();
	}
	IEnumerator Disparo3 (){
		yield return new WaitForSeconds (0.35f);
		disparo3.Play ();
	}
}

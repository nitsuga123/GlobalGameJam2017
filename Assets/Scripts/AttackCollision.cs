using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour {

    [SerializeField]
    private float BatTimeToDie;
    [SerializeField]
    private Transform player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("BatRed") && (this.gameObject.tag=="Red"))
        {
            Animator anim = collider.gameObject.GetComponent<Animator>();
            anim.SetTrigger("BatDie");

            GameManager.Instance.score += 10f;

            StartCoroutine(BatDie(collider));
        }
        else {
            Attacks.Instance.EndRed();
            Attacks.Instance.EndBlue();
            Attacks.Instance.EndYellow();
            transform.position = player.position;
        }
        if (collider.gameObject.CompareTag("BatYellow") && (this.gameObject.tag == "Yellow"))
        {
            Animator anim = collider.gameObject.GetComponent<Animator>();
            anim.SetTrigger("BatDie");

            GameManager.Instance.score += 10f;

            StartCoroutine(BatDie(collider));
        }
        else
        {
            Attacks.Instance.EndRed();
            Attacks.Instance.EndBlue();
            Attacks.Instance.EndYellow();
            transform.position = player.position;
        }
        if (collider.gameObject.CompareTag("BatBlue") && (this.gameObject.tag == "Blue"))
        {
            Animator anim = collider.gameObject.GetComponent<Animator>();
            anim.SetTrigger("BatDie");

            GameManager.Instance.score += 10f;

            StartCoroutine(BatDie(collider));
        }
        else
        {
            Attacks.Instance.EndRed();
            Attacks.Instance.EndBlue();
            Attacks.Instance.EndYellow();
            transform.position = player.position;
        }
    }

    //Other functions

    private IEnumerator BatDie(Collider2D collider)
    {
        yield return new WaitForSeconds(BatTimeToDie);
        
        Attacks.Instance.EndRed();
        Attacks.Instance.EndBlue();
        Attacks.Instance.EndYellow();
        transform.position = player.position;
        Pool_Enemys.pool_enemys.DesactiveBat(collider);
        collider.GetComponent<Animator>().Stop();
        collider.GetComponent<Animator>().Play("BatRedDefault");
    }
}



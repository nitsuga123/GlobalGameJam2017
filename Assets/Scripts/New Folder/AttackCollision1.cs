using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision1 : MonoBehaviour {

    [SerializeField]
    private float scoreDelta;
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

        if (collider.gameObject.tag.Equals(this.gameObject.tag))
        {
            Pool_Enemys.pool_enemys.DesactiveBat(collider);
            AttackBehaviour.Instance.EndRed();
            AttackBehaviour.Instance.EndBlue();
            AttackBehaviour.Instance.EndYellow();
            transform.position = player.position;

            GameManager.Instance.score += scoreDelta;
        }
        else
        {
            AttackBehaviour.Instance.EndRed();
            AttackBehaviour.Instance.EndBlue();
            AttackBehaviour.Instance.EndYellow();
            transform.position = player.position;
        }
    }


    void OnTriggerExit2D(Collider2D c)
    {
        Debug.Log("rip");
        if (c.gameObject.CompareTag("GameController"))
        {
            Debug.Log("rip");
            c.gameObject.transform.position = player.transform.position;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour {

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
            Attacks.Instance.EndRed();
            Attacks.Instance.EndBlue();
            Attacks.Instance.EndYellow();
            transform.position = player.position;

        }
        else {
            Attacks.Instance.EndRed();
            Attacks.Instance.EndBlue();
            Attacks.Instance.EndYellow();
            transform.position = player.position;
        }
       /* if (collider.gameObject.CompareTag("Blue"))
        {

            Pool_Enemys.pool_enemys.DesactiveBat(collider);
            Attacks.Instance.EndBlue();
            transform.position = player.position;


        }
        if (collider.gameObject.CompareTag("Yellow"))
        {

            Pool_Enemys.pool_enemys.DesactiveBat(collider);
            Attacks.Instance.EndYellow();
            transform.position = player.position;
        }
        */
    }


    }



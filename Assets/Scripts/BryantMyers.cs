using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BryantMyers : MonoBehaviour {

    [SerializeField]
    private float scoreToMyers;
    [SerializeField]
    private AudioSource bryantMyers;
    [SerializeField]
    private Animator bryantMyersAnim;

    //Unity functions

    void Update()
    {
        if (Score.Instance.score == scoreToMyers)
        {
            bryantMyers.Play();

            bryantMyersAnim.SetBool("bryantMyers", true);
        }
    }
}
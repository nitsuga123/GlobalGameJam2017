using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BryantMyers : MonoBehaviour {

    [SerializeField]
    private float scoreToMyers;
    [SerializeField]
    private AudioSource bryantMyers;

    void Update()
    {
        if (Score.Instance.score == scoreToMyers)
        {
            bryantMyers.Play();
        }
    }
}
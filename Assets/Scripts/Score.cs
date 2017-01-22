﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    private static Score instance;
    public static Score Instance
    {
        get
        {
            return instance;
        }
    }


    [HideInInspector]
    public float score = 0;
    [SerializeField]
    private float scoreToChange;
    [SerializeField]
    private float scoreDelta;
    [SerializeField]
    private float timeLefToChange;
    [SerializeField]
    private float velocityChange;
    [SerializeField]
    private Text scoreText;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

        scoreText.text = "Score= " + score;


        if (score == scoreToChange)
        {
            ChangeRound();
            scoreToChange += scoreDelta;
        }
    }

    //Other functions

    public void ChangeRound()
    {
        Spawn.Instance.timeleft -= timeLefToChange;
        Enemy.speed += velocityChange;

    }

}

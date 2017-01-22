using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private bool gameEnd;
    public Image[] hearts = new Image[3];
    [SerializeField]
    private Die player;
    [HideInInspector]
    public float score=0;
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

    [Header("Images")]

    private GameObject restart;

    //Unity functions

    void Awake()
    {
        if (instance == null)
        {
             instance= this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

        scoreText.text = "Score= " + score;

        if (gameEnd)
        {
            restart.SetActive(true);
        }

        if (Input.GetButtonDown("Restart") && restart.activeInHierarchy == true)
        {
            restart.SetActive(false);

            SceneManager.LoadScene(0);
        }

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
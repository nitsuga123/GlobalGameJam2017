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
    public float score;
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
        scoreText.text = "Score: " + score.ToString();
        if (gameEnd)
        {
            restart.SetActive(true);
        }

        if (Input.GetButtonDown("Restart") && restart.activeInHierarchy == true)
        {
            restart.SetActive(false);

            SceneManager.LoadScene(0);
        }
    }


}
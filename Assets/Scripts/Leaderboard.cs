using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

    private static Leaderboard instance;
    public static Leaderboard Instance
    {
        get
        {
            return instance;
        }
    }

    public bool gameEnd;
    public int[] score = new int[3]; //The score[0] is the Min and the score[2] is the Max
    public string[] scoreName = new string[3];

    [SerializeField]
    private Text[] scores = new Text[3];

    [SerializeField]
    private InputField inputField;

    //Unity functions

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

    void Start()
    {
        SetText();
    }

    void Update()
    {
        string inputFieldText = inputField.text;
        CompareScore(inputFieldText, Score.Instance.score);

        if (gameEnd)
        {
            if (ButtonsFunction.Instance.menuScreens[3].activeInHierarchy && Input.GetKeyDown(KeyCode.Y))
            {
                ButtonsFunction.Instance.Enter();
            }
        }
    }

    //Other functions

    public void CompareScore (string _scoreName, int _score)
    {
        if (_score > score[0])
        {
            if (_score>score[1])
            {
                if(_score>score[2])
                {
                    score[0] = score[1];
                    scoreName[0] = scoreName[1];
                    score[1] = score[2];
                    scoreName[1] = scoreName[2];
                    score[2] = _score;
                    scoreName[2] = _scoreName;

                    //Playerprefs

                    PlayerPrefs.SetInt("score0", score[1]);
                    PlayerPrefs.SetString("scoreName0", scoreName[1]);
                    PlayerPrefs.SetInt("score1", score[2]);
                    PlayerPrefs.SetString("scoreName1", scoreName[2]);
                    PlayerPrefs.SetInt("score2", _score);
                    PlayerPrefs.SetString("scoreName2", _scoreName);

                    SetText();
                }
                else
                {
                    score[0] = score[1];
                    scoreName[0] = scoreName[1];
                    score[1] = _score;
                    scoreName[1] = _scoreName;

                    //Playerprefs

                    PlayerPrefs.SetInt("score0", score[1]);
                    PlayerPrefs.SetString("scoreName0", scoreName[1]);
                    PlayerPrefs.SetInt("score1", _score);
                    PlayerPrefs.SetString("scoreName1", _scoreName);

                    SetText();
                }
            }
            else
            {
                score[0] = _score;
                scoreName[0] = _scoreName;

                //Playerprefs

                PlayerPrefs.SetInt("score0", _score);
                PlayerPrefs.SetString("scoreName0", _scoreName);

                SetText();
            }
        }
        else
        {
            Debug.Log("Sorry :(");
        }
    }

    private void SetText()
    {
        int position = 1;
        int score = 0;

        foreach (Text text in scores)
        {
            text.text = position + ". " + PlayerPrefs.GetString("scoreName" + score.ToString()) + ": " + PlayerPrefs.GetInt("score" + score.ToString());
            position++;
            score++;
        }
    }
}
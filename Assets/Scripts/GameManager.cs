using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private bool gameEnd;

    [Header("Images")]

    private GameObject restart;

    //Unity functions

    void Update()
    {
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
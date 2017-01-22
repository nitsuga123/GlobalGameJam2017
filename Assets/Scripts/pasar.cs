using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasar : MonoBehaviour {

    [SerializeField]
    private float timeToWait;

    void Update()
    {
        Time.timeScale = 1;
        Debug.Log(timeToWait);
        timeToWait += 1 * Time.deltaTime;
        if (timeToWait > 3)
        {
            SceneManager.LoadScene(3);
        }
    }
}

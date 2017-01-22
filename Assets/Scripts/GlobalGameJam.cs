using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameJam : MonoBehaviour {

    [SerializeField]
    private float timeToWait;

    void Start ()
    {
        StartCoroutine(GlobalGameJam2017());
	}

    //Other functions

    public IEnumerator GlobalGameJam2017()
    {
        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(0);
    }
}
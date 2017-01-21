using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    [SerializeField]
    private float velocity;
    [SerializeField]
    private float timeToWait;

    [SerializeField]
    private Rigidbody credits;

    //Unity functions

    void Start()
    {
        StopAllCoroutines();

        credits.velocity = Vector3.up * velocity;

        StartCoroutine(CreditsEnd());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    //Other functions

    public IEnumerator CreditsEnd()
    {
        yield return new WaitForSeconds(timeToWait);

        SceneManager.LoadScene(0);
    }
}
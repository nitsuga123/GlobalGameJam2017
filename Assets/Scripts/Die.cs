using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour {

    [HideInInspector]
    public int hitCount;
    [SerializeField]
    private float timeToDie;
    
    //Unity functions

    void Start()
    {
        hitCount = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            GameManager.Instance.hearts[hitCount].gameObject.SetActive(false);
            hitCount++;

            Animator batAnim = other.gameObject.GetComponent<Animator>();

            batAnim.SetTrigger("BatDie");

            if (hitCount == 3)
            {
                StartCoroutine(GameOver());
            }
        }
    }

    //Other functions

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds (timeToDie);

        SceneManager.LoadScene(0);
    }
}
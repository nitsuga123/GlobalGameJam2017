using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour {

    [SerializeField]
    private float secondsToWait = 13f;

    [SerializeField]
    private GameObject[] menuScreens = new GameObject[3];
    
    //Unity functions

    void Start()
    {
        StopAllCoroutines();

        menuScreens[0].SetActive(true);
        menuScreens[1].SetActive(true);
        menuScreens[2].SetActive(false);

        StartCoroutine(DesactiveLogo());
    }
    
    //Buttons functions

    public void Play()
    {
        ActiveMenus(false);

        //TODO: PLAY
    }

    public void Scores()
    {
        menuScreens[1].SetActive(false);
        menuScreens[2].SetActive(true);
    }

    public void Credits()
    {
        menuScreens[1].SetActive(false);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        menuScreens[2].SetActive(false);
        menuScreens[1].SetActive(true);
    }

    //Other functions

    public void ActiveMenus(bool state)
    {
        foreach(GameObject menuScreen in menuScreens)
        {
            menuScreen.SetActive(state);
        }
    }

    private IEnumerator DesactiveLogo()
    {
        yield return new WaitForSeconds(secondsToWait);
        menuScreens[0].SetActive(false);
    }
}
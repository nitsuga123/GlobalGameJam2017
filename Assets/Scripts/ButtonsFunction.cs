using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class ButtonsFunction : MonoBehaviour {

    private static ButtonsFunction instance;
    public static ButtonsFunction Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private bool menuIsActive;

    [SerializeField]
    private float secondsToWait = 13f;

    public GameObject[] menuScreens = new GameObject[4];

    [Header("Camera things")]

    [SerializeField]
    private GameObject blurImage;
    [SerializeField]
    private Camera blurCamera;
    
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
        StopAllCoroutines();

        menuIsActive = true;

        Time.timeScale = 0;

        menuScreens[0].SetActive(true);
        menuScreens[1].SetActive(true);
        menuScreens[2].SetActive(false);

        StartCoroutine(DesactiveLogo());
    }

    void Update()
    {
        if (menuIsActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Scores();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                if (menuScreens[2].activeInHierarchy)
                {
                    Back();
                }
                else
                {
                    Play();
                }
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Credits();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Exit();
            }
        }
    }
    
    //Buttons functions

    public void Play()
    {
        ActiveMenus(false);

        Time.timeScale = 1;

        blurCamera.GetComponent<BlurOptimized>().enabled = false;
        blurImage.SetActive(false);

        menuIsActive = false;
    }

    public void Scores()
    {
        menuScreens[1].SetActive(false);
        menuScreens[2].SetActive(true);
    }

    public void Credits()
    {
        menuScreens[1].SetActive(false);

        Time.timeScale = 1;

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
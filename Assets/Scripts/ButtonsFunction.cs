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

    [SerializeField]
    private Shoot shoot;

    public GameObject[] menuScreens = new GameObject[3];

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
        menuScreens[1].SetActive(false);
        menuScreens[2].SetActive(false);


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
        shoot.isInMenu = false;
    }

    public void Scores()
    {
        menuScreens[0].SetActive(false);
        menuScreens[1].SetActive(true);
    }

    public void Credits()
    {
        menuScreens[0].SetActive(false);

        Time.timeScale = 1;

        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        menuScreens[1].SetActive(false);
        menuScreens[0].SetActive(true);
    }

    public void Enter()
    {
        SceneManager.LoadScene("juego");
    }

    //Other functions

    public void ActiveMenus(bool state)
    {
        foreach(GameObject menuScreen in menuScreens)
        {
            menuScreen.SetActive(state);
        }
    }


}